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
    val inline ( |?-> ) :
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
    val inline ( |>? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullMap or  ^a) : (static member Into :  ^a *  ^b ->  ^c)
    val inline ( ?<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullMap or  ^b) : (static member Into :  ^b *  ^a ->  ^c)
    type NullBind =
      class
        static member Into : a:'a option * f:('a -> 't option) -> 't option
        static member Into : a:'a option * f:('a -> System.Nullable<'t>) -> 't option
                   when 't : (new : unit -> 't) and 't : struct and
                        't :> System.ValueType
        static member Into : a:'a option * f:('a -> 't) -> 't option when 't : null
        static member Into : a:System.Nullable<'a> * f:('a -> 't option) -> 't option
                   when 'a : (new : unit -> 'a) and 'a : struct and
                        'a :> System.ValueType
        static member Into : a:System.Nullable<'a> * f:('a -> System.Nullable<'t>) ->
                   't option
                   when 'a : (new : unit -> 'a) and 'a : struct and
                        'a :> System.ValueType and 't : (new : unit -> 't) and
                        't : struct and 't :> System.ValueType
        static member Into : a:System.Nullable<'a> * f:('a -> 't) -> 't option
                   when 'a : (new : unit -> 'a) and 'a : struct and
                        'a :> System.ValueType and 't : null
        static member Into : a:'a * f:('a -> 't option) -> 't option when 'a : null
        static member Into : a:'a * f:('a -> System.Nullable<'t>) -> 't option
                   when 'a : null and 't : (new : unit -> 't) and 't : struct and
                        't :> System.ValueType
        static member
          Into : a:'a * f:('a -> 't) -> 't option when 'a : null and 't : null
      end
    val inline ( |>?? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullBind or  ^a) : (static member Into :  ^a *  ^b ->  ^c)
    val inline ( ??<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullBind or  ^b) : (static member Into :  ^b *  ^a ->  ^c)
  end

