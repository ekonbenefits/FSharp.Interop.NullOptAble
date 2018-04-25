namespace FSharp.Interop.NullOptAble
  module Operators = begin
    type NullCoalesce =
      class
        static member Coalesce : a:'a option * b:System.Lazy<'a> -> 'a
        static member Coalesce : a:System.Nullable<'a> * b:System.Lazy<'a> -> 'a
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member Coalesce : a:'a * b:System.Lazy<'a> -> 'a when 'a : null
      end
    val inline ( |?? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullCoalesce or  ^a) : (static member Coalesce :  ^a *  ^b ->  ^c)
    type NullMap =
      class
        static member Into : a:'a option * f:('a -> 't) -> 't option
        static member Into : a:System.Nullable<'a> * f:('a -> 't) -> 't option
                   when 'a : (new : unit -> 'a) and 'a : struct and
                        'a :> System.ValueType
        static member Into : a:'a * f:('a -> 't) -> 't option when 'a : null
      end
    val inline ( |?|> ) :
      a: ^a -> b: ^b ->  ^c
        when (NullMap or  ^a) : (static member Into :  ^a *  ^b ->  ^c)
    type NullBind =
      class
        static member Into : a:'a option * f:('a -> 't option) -> 't option
        static member Into : a:System.Nullable<'a> * f:('a -> 't option) -> 't option
                   when 'a : (new : unit -> 'a) and 'a : struct and
                        'a :> System.ValueType
        static member Into : a:'a * f:('a -> 't option) -> 't option when 'a : null
      end
  end

