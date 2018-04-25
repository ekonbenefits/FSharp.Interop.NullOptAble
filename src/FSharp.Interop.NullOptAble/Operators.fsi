namespace FSharp.Interop.NullOptAble
  module Operators =
    type NullCoalesce =
      class
        static member Coalesce : a:'a option * b:System.Lazy<'a> -> 'a
        static member
          Coalesce : a:System.Nullable<'a> * b:System.Lazy<'a> -> 'a
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member Coalesce : a:'a * b:System.Lazy<'a> -> 'a when 'a : null
      end
    val inline ( |?? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullCoalesce or  ^a) : (static member Coalesce :  ^a *  ^b ->  ^c)


