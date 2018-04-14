[<AutoOpen>]
module FSharp.Core.Experimental.OptionBuilder.TopLevel
open System

type OptionBuilder() =
    member __.Zero() = None

    member __.Return(x: 'T) = Some x

    member __.ReturnFrom(m: 'T option) = m
    member __.ReturnFrom(m: 'T Nullable) = Option.ofNullable m
    member __.ReturnFrom(m: 'T) = Option.ofObj m

    member __.Bind(m: 'T option, f) = Option.bind f m
    member __.Bind(m: 'T Nullable, f) = m |> Option.ofNullable |> Option.bind f
    member __.Bind(m: 'T, f) = m |> Option.ofObj |> Option.bind f

    member __.Delay(f: unit -> _) = f
    member __.Run(f) = f()

    member this.TryWith(delayedExpr, handler) =
        try this.Run(delayedExpr)
        with exn -> handler exn
    member this.TryFinally(delayedExpr, compensation) =
        try this.Run(delayedExpr)
        finally compensation()
    member this.Using(resource:#IDisposable, body) =
        this.TryFinally(this.Delay(fun ()->body resource), fun () -> match resource with null -> () | disp -> disp.Dispose())

let option = OptionBuilder()

type SeqOptionBuilder() =
    member __.Zero() = Seq.empty

    member __.Yield(x: 'T) = seq { yield x }
    member __.YieldFrom(m: 'T seq) : 'T seq = m

    member __.YieldFrom(m: 'T option) : 'T seq =  m |> Option.toList
                                                    |> List.toSeq
    member __.YieldFrom(m: 'T Nullable) : 'T seq =  m |> Option.ofNullable
                                                      |> Option.toList
                                                      |> List.toSeq
    member __.YieldFrom(m: 'T) : 'T seq = m |> Option.ofObj
                                            |> Option.toList
                                            |> List.toSeq

    member __.Combine(m1: 'T seq, m2: 'T seq) : 'T seq = Seq.append m1 m2

    member __.Delay(f: unit -> _) = f
    member __.Run(f) = f()

    member this.TryWith(delayedExpr, handler) =
        try this.Run(delayedExpr)
        with exn -> handler exn
    member this.TryFinally(delayedExpr, compensation) =
        try this.Run(delayedExpr)
        finally compensation()
    member this.Using(resource:#IDisposable, body) =
        this.TryFinally(this.Delay(fun ()->body resource), fun () -> match resource with null -> () | disp -> disp.Dispose())

    member this.While(guard, delayedExpr) =
        while guard() do
            this.Run(delayedExpr)
        this.Zero()
    member this.For(sequence:seq<_>, body) =
        this.Using(sequence.GetEnumerator(), 
            fun enum -> this.While(enum.MoveNext, this.Delay(fun () -> body enum.Current)))

let seqOption = SeqOptionBuilder()