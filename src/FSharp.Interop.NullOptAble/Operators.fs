namespace FSharp.Interop.NullOptAble

module Operators =

    
    //static overloading operators inspired by http://stackoverflow.com/a/2812306/637783
    let inline defaultWithOverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member DefaultWith : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member DefaultWith : ^a * ^b -> ^c) (a, b))
    let inline mapOverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Map : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Map : ^a * ^b -> ^c) (a, b))
    let inline map2OverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Map2 : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Map2 : ^a * ^b -> ^c) (a, b))
    let inline map3OverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Map3 : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Map3 : ^a * ^b -> ^c) (a, b))
    let inline bindOverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Bind : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Bind : ^a * ^b -> ^c) (a, b))
    let inline bind2OverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Bind2 : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Bind2 : ^a * ^b -> ^c) (a, b))
    let inline bind3OverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Bind3 : ^a * ^b -> ^c)> a b = 
        ((^t or ^a) : (static member Bind3 : ^a * ^b -> ^c) (a, b))

    (* default with *)
    let inline ( |?-> ) a b = defaultWithOverloadHelper<NullOptAble, _, _, _> a b
    (* map *)
    let inline ( |>?@ ) a b = mapOverloadHelper<NullOptAble, _, _, _> a b
    let inline ( @?<| ) b a = mapOverloadHelper<NullOptAble, _, _, _> a b
    (* map2 *)
    let inline ( ||>?@ ) a b = map2OverloadHelper<NullOptAble, _, _, _> a b
    let inline ( @?<|| ) b a = map2OverloadHelper<NullOptAble, _, _, _> a b
    (* map3 *)
    let inline ( |||>?@ ) a b = map3OverloadHelper<NullOptAble, _, _, _> a b
    let inline ( @?<||| ) b a = map3OverloadHelper<NullOptAble, _, _, _> a b
    (* bind *)
    let inline ( |>? ) a b = bindOverloadHelper<NullOptAble, _, _, _> a b
    let inline ( ?<| ) b a = bindOverloadHelper<NullOptAble, _, _, _> a b
    (* bind2 *)
    let inline ( ||>? ) a b = bind2OverloadHelper<NullOptAble, _, _, _> a b
    let inline ( ?<|| ) b a = bind2OverloadHelper<NullOptAble, _, _, _> a b
    (* bind3 *)
    let inline ( |||>? ) a b = bind3OverloadHelper<NullOptAble, _, _, _> a b
    let inline ( ?<||| ) b a = bind3OverloadHelper<NullOptAble, _, _, _> a b