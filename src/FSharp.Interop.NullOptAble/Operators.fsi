namespace FSharp.Interop.NullOptAble
  module Operators = begin
    val inline ( |?-> ) :
      a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member DefaultWith :  ^a *  ^b ->
                                                                    ^c)
    val inline ( |>?@ ) :
      a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Map :  ^a *  ^b ->  ^c)
    val inline ( @?<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullOptAble or  ^b) : (static member Map :  ^b *  ^a ->  ^c)
    val inline ( ||>?@ ) :
      a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Map2 :  ^a *  ^b ->  ^c)
    val inline ( @?<|| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullOptAble or  ^b) : (static member Map2 :  ^b *  ^a ->  ^c)
    val inline ( |>? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Bind :  ^a *  ^b ->  ^c)
    val inline ( ?<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullOptAble or  ^b) : (static member Bind :  ^b *  ^a ->  ^c)
    val inline ( ||>? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Bind2 :  ^a *  ^b ->  ^c)
    val inline ( ?<|| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullOptAble or  ^b) : (static member Bind2 :  ^b *  ^a ->  ^c)
  end