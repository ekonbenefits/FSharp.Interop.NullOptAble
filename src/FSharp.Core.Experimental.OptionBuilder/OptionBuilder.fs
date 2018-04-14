[<AutoOpen>]
module FSharp.Core.Experimental.OptionBuilder.TopLevel
open System

type OptionBuilder() =
    member __.Zero() = None

    member __.Return(x: 'T) = Some x

    member __.ReturnFrom(m: 'T option) = m
    member __.ReturnFrom(m: 'T Nullable) = Option.ofNullable m
    member __.ReturnFrom(m: 'T when 'T:null) = Option.ofObj m

    member __.Bind(m: 'T option, f) = Option.bind f m
    member __.Bind(m: 'T Nullable, f) = m |> Option.ofNullable |> Option.bind f
    member __.Bind(m: 'T when 'T:null, f) = m |> Option.ofObj |> Option.bind f

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

type ChooseSeqBuilder() =
    member __.Zero() = Seq.empty

    member __.Yield(x: 'T) = Seq.singleton x

    member this.YieldFrom(m: 'T option) =  m |> function | None -> this.Zero ()
                                                         | Some x -> this.Yield(x)
    member this.YieldFrom(m: 'T Nullable) =  m |> Option.ofNullable
                                               |> this.YieldFrom
    member this.YieldFrom(m: 'T when 'T:null) = m |> Option.ofObj
                                                  |> this.YieldFrom
    member __.YieldFrom(m: 'T seq) = m |> Option.ofObj
                                       |> Option.defaultValue Seq.empty
    member this.YieldFrom(m: string) = m |> Option.ofObj
                                         |> this.YieldFrom

    member __.Bind(m: 'T option, f) = Option.bind f m
    member __.Bind(m: 'T Nullable, f) = m |> Option.ofNullable |> Option.bind f
    member __.Bind(m: 'T, f) = m |> Option.ofObj |> Option.bind f

    member __.Combine(a, b) =  Seq.append a b

    member __.Delay(f: unit -> _) = Seq.delay f
    member __.Run(f) : 'T seq = f |> List.ofSeq :> 'T seq

    member this.While(guard, delayedExpr) =
        let mutable result = this.Zero()
        while guard() do
            result <- this.Combine(result,this.Run(delayedExpr))
        result

    member this.TryWith(delayedExpr, handler) =
        try this.Run(delayedExpr)
        with exn -> handler exn
    member this.TryFinally(delayedExpr, compensation) =
        try this.Run(delayedExpr)
        finally compensation()
    member this.Using(resource:#IDisposable, body) =
        this.TryFinally(this.Delay(fun ()->body resource), fun () -> match resource with null -> () | disp -> disp.Dispose())

    member this.For(sequence:seq<_>, body) =
        this.Using(sequence.GetEnumerator(), 
            fun enum -> this.While(enum.MoveNext, this.Delay(fun () -> body enum.Current)))

let chooseSeq = ChooseSeqBuilder()