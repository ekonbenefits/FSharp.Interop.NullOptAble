namespace FSharp.Interop.NullOptAble

open System

[<AutoOpen>]
module TopLevelBuilders =

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
            this.TryFinally(this.Delay(fun ()->body resource), fun () -> match box resource with null -> () | _ -> resource.Dispose())

    let option = OptionBuilder()


    module ChooseSeq =

        let forceRun delayedSeq = delayedSeq |> List.ofSeq :> 'T seq 

    type ChooseSeqBuilder() =
        member __.Zero<'T>() = Seq.empty<'T>

        member __.Yield(x: 'T) = Seq.singleton x

        member this.YieldFrom(m: 'T option) =  m |> function | None -> this.Zero ()
                                                             | Some x -> this.Yield(x)
        member this.YieldFrom(m: 'T Nullable) =  m |> Option.ofNullable
                                                   |> this.YieldFrom
        member this.YieldFrom(m: 'T when 'T:null) = m |> Option.ofObj
                                                      |> this.YieldFrom
        member this.YieldFrom(m: 'T seq) = m |> Option.ofObj
                                             |> Option.defaultValue (this.Zero<'T>())

        //mrg special casing string, is this really okay,
        //it's a strange type, or is this a design issue manifesting?
        member this.YieldFrom(m: string) = m |> Option.ofObj
                                             |> Option.map(Seq.toArray >> Seq.ofArray)
                                             |> Option.defaultValue (this.Zero<char>())

        member this.Bind(m: 'T option, f:'T->seq<'S>) : seq<'S> = 
            match m with
                     | Some x -> f x
                     | None -> this.Zero<'S>()

        member this.Bind(m: 'T Nullable, f) = 
            let m' = m |> Option.ofNullable 
            this.Bind(m', f)
        member this.Bind(m: 'T when 'T:null, f) = 
            let m' = m |> Option.ofObj
            this.Bind(m', f)

        member __.Combine(a, b) =  Seq.append a b

        member __.Delay(f: unit -> _) = Seq.delay f

        member __.Run(f:seq<_>) = f //make this a delayed sequence

        member this.While(guard, delayedExpr) =
            let mutable result = this.Zero()
            while guard() do
                result <- this.Combine(result,ChooseSeq.forceRun(delayedExpr))
            result

        member __.TryWith(delayedExpr, handler) =
            try ChooseSeq.forceRun(delayedExpr)
            with exn -> handler exn
        member __.TryFinally(delayedExpr, compensation) =
            try ChooseSeq.forceRun(delayedExpr)
            finally compensation()
        member this.Using(resource:#IDisposable, body) =
            this.TryFinally(this.Delay(fun ()->body resource), fun () -> match box resource with null -> () | _ -> resource.Dispose())

        member this.For(sequence:seq<_>, body) =
            this.Using(sequence.GetEnumerator(), 
                fun enum -> this.While(enum.MoveNext, this.Delay(fun () -> body enum.Current)))

    let chooseSeq = ChooseSeqBuilder()