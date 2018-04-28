namespace FSharp.Interop.NullOptAble
  module Operators = begin
    (* default with *)
    val inline ( |?-> ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member DefaultWith : ^a * ^b -> ^c)
    (* map *)
    val inline ( |>?@ ) : a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Map : ^a * ^b -> ^c)
    val inline ( @?<| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map : ^b * ^a -> ^c)
    (* map2 *)
    val inline ( ||>?@ ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Map2 : ^a * ^b -> ^c)
    val inline ( @?<|| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map2 : ^b * ^a -> ^c)
    (* map3 *)
    val inline ( |||>?@ ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Map3 : ^a * ^b -> ^c)
    val inline ( @?<||| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map3 : ^b * ^a -> ^c)
    (* bind *)
    val inline ( |>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind : ^a * ^b -> ^c)
    val inline ( ?<| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind : ^b * ^a -> ^c)
    (* bind2 *)
    val inline ( ||>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind2 : ^a * ^b -> ^c)
    val inline ( ?<|| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind2 : ^b * ^a -> ^c)
    (* bind3 *)
    val inline ( |||>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind3 : ^a * ^b -> ^c)
    val inline ( ?<||| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind3 : ^b * ^a -> ^c)
  end