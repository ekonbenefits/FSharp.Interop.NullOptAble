namespace FSharp.Interop.NullOptAble.Experimental.ValueOption

[<StructuralEquality; StructuralComparison>]
[<Struct>]
[<CompiledName("FSharpValueOption`1")>]
type ValueOption<'T> =
    | VNone : 'T voption
    | VSome : 'T -> 'T voption
    member x.Value = match x with VSome x -> x | VNone -> raise (new System.InvalidOperationException("ValueOption.Value"))
and 'T voption = ValueOption<'T>