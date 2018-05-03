namespace FSharp.Interop.NullOptAble
open System

[<RequireQualifiedAccess>]
module Option =

    let ofTryTuple = function | (true, item) -> Some(item) | (false, _) -> None
    let ofStringWhen (predicate: string -> bool) = function | w when predicate w -> w |> Option.ofObj | _ -> None
    let ofStringWhenNot (predicate: string -> bool) = function | w when (predicate >> not) w  -> w |> Option.ofObj | _ -> None