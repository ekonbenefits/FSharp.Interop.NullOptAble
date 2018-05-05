namespace FSharp.Interop.NullOptAble

open System
open FSharp.Interop.NullOptAble.Experimental

[<AutoOpen>]
module TopLevelBuilders =
    type OptionBuilder() =
        member __.Zero() =
            None
        member __.Return(x: 'T) =
            Some x
        member __.ReturnFrom(m: 'T voption) =
            Option.ofValueOption m
        member __.ReturnFrom(m: 'T option) = 
            m
        member __.ReturnFrom(m: 'T Nullable) = 
            Option.ofNullable m
        member __.ReturnFrom(m: 'T when 'T:null) =
            Option.ofObj m
        member __.Bind(m: 'T option, f) = 
            m |> Option.bind f
        member __.Bind(m: 'T voption, f) = 
            m |> Option.ofValueOption |> Option.bind f
        member __.Bind(m: 'T Nullable, f) = 
            m |> Option.ofNullable |> Option.bind f
        member __.Bind(m: 'T when 'T:null, f) = 
            m |> Option.ofObj |> Option.bind f
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
    
    type ValueOptionBuilder() =
        member __.Zero() = VNone
        member __.Return(x: 'T) = VSome x
        member __.ReturnFrom(m: 'T voption) = m
        member __.ReturnFrom(m: 'T option) = ValueOption.ofOption m
        member __.ReturnFrom(m: 'T Nullable) = ValueOption.ofNullable m
        member __.ReturnFrom(m: 'T when 'T:null) = ValueOption.ofObj m
        member __.Bind(m: 'T voption, f) = 
            m |> ValueOption.bind f
        member __.Bind(m: 'T option, f) = 
            m |> ValueOption.ofOption |> ValueOption.bind f
        member __.Bind(m: 'T Nullable, f) = 
            m |> ValueOption.ofNullable |> ValueOption.bind f
        member __.Bind(m: 'T when 'T:null, f) = 
            m |> ValueOption.ofObj |> ValueOption.bind f

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
    let voption = ValueOptionBuilder()


    module ChooseSeq =
        let forceRun delayedSeq = delayedSeq |> List.ofSeq :> 'T seq 

    type private CombineOptimized<'T>() =
        inherit System.Collections.Generic.List<'T>()

    type ChooseSeqBuilder() =
        member __.Zero<'T>() = Seq.empty<'T>

        member __.Yield(x: 'T) = Seq.singleton x

        member this.YieldFrom(m: 'T voption) : 'T seq = 
                m |> function | VNone -> this.Zero ()
                              | VSome x -> this.Yield(x)
        member this.YieldFrom(m: 'T option) : 'T seq = 
                m |> function | None -> this.Zero ()
                              | Some x -> this.Yield(x)
        member this.YieldFrom(m: 'T Nullable seq) :'T seq =
                m |> Option.ofObj
                  |> Option.map (Seq.choose Option.ofNullable)
                  |> Option.defaultValue (this.Zero<'T>())

        member this.YieldFrom(m: 'T seq when 'T:null) :'T seq =
                m |> Option.ofObj
                  |> Option.map (Seq.choose Option.ofObj)
                  |> Option.defaultValue (this.Zero<'T>())
    
        member this.YieldFrom(m: 'T option seq) :'T seq =
                m |> Option.ofObj
                  |> Option.map (Seq.choose id)
                  |> Option.defaultValue (this.Zero<'T>())

        member this.YieldFrom(m: 'T voption seq) :'T seq =
                m |> Option.ofObj
                  |> Option.map (Seq.choose Option.ofValueOption)
                  |> Option.defaultValue (this.Zero<'T>())

        member this.Bind(m: 'T option, f:'T->seq<'S>) : seq<'S> = 
            match m with
                     | Some x -> f x
                     | None -> this.Zero<'S>()
        member this.Bind(m: 'T voption, f:'T->seq<'S>) : seq<'S> = 
            match m with
                     | VSome x -> f x
                     | VNone -> this.Zero<'S>()
        member this.Bind(m: 'T Nullable, f) = 
            let m' = m |> Option.ofNullable 
            this.Bind(m', f)
        member this.Bind(m: 'T when 'T:null, f) = 
            let m' = m |> Option.ofObj
            this.Bind(m', f)

        member __.Combine(a:seq<'T>, b:seq<'T>) : seq<'T>= 
            let list =
                match a with
                    | :? CombineOptimized<'T> as l -> l
                    | _ -> let l = CombineOptimized<'T>()
                           l.AddRange(a)
                           l
            list.AddRange(b)
            upcast list

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