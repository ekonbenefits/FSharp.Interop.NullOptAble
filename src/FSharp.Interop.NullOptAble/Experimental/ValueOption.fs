namespace FSharp.Interop.NullOptAble.Experimental

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
