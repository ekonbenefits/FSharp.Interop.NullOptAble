namespace FSharp.Interop.NullOptAble.Experimental.ValueOption

open System
[<RequireQualifiedAccess>]
module ValueOption =
    let ofOption = function | Some x -> VSome x | None -> VNone
    let ofNullable (value:'t Nullable) = if value.HasValue then VSome value.Value else VNone
    let ofObj = function | null -> VNone | x -> VSome x
    let ofTryTuple = function | (true, item) -> VSome(item) | (false, _) -> VNone
    let bind binder = function | VNone -> VNone | VSome x -> binder x
    let map mapping = function |  VNone -> VNone | VSome x -> VSome (mapping x)
    let defaultValue value = function |  VNone -> value | VSome v -> v
    let defaultWith defThunk = function | VNone -> defThunk () | VSome v -> v
[<RequireQualifiedAccess>]
module Option =
    let ofValueOption = function | VSome x -> Some x | VNone -> None

[<AutoOpen>]
module TopLevelBuilder =
    type ValueOptionBuilder() =
        member __.Zero() = VNone

        member __.Return(x: 'T) = VSome x

        member __.ReturnFrom(m: 'T option) = ValueOption.ofOption m
        member __.ReturnFrom(m: 'T Nullable) = ValueOption.ofNullable m
        member __.ReturnFrom(m: 'T when 'T:null) = ValueOption.ofObj m

        member __.Bind(m: 'T voption, f) = ValueOption.bind f m
        member __.Bind(m: 'T option, f) = m |> ValueOption.ofOption |> ValueOption.bind f
        member __.Bind(m: 'T Nullable, f) = m |> ValueOption.ofNullable |> ValueOption.bind f
        member __.Bind(m: 'T when 'T:null, f) = m |> ValueOption.ofObj |> ValueOption.bind f

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
