namespace FSharp.Interop.NullOptAble
open System

[<RequireQualifiedAccess>]
module Option =

    [<CompiledName("OfTryTuple")>]
    let ofTryTuple = function | (true, item) -> Some(item) | (false, _) -> None
    [<CompiledName("OfObjWhen")>]
    let ofObjWhen predicate = function | w when predicate w -> w |> Option.ofObj | _ -> None
    [<CompiledName("OfObjWhenNot")>]
    let ofObjWhenNot predicate = function | w when (predicate >> not) w  -> w |> Option.ofObj | _ -> None