namespace FSharp.Interop.NullOptAble
  module Operators = begin
    type NullCoalesce =
      class
        static member Operator : a:'a option * b:System.Lazy<'a> -> 'a
        static member
          Operator : a:System.Nullable<'a> * b:System.Lazy<'a> -> 'a
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member Operator : a:'a * b:System.Lazy<'a> -> 'a when 'a : null
      end
    val inline ( |?-> ) :
      a: ^a -> b: ^b ->  ^c
        when (NullCoalesce or  ^a) : (static member Operator :  ^a *  ^b ->  ^c)
    type NullMap =
      class
        static member Operator : a:'a option * f:('a -> 't) -> 't option
        static member
          Operator : a:System.Nullable<'a> * f:('a -> 't) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member Operator : a:'a * f:('a -> 't) -> 't option when 'a : null
      end
    val inline ( |>?@ ) :
      a: ^a -> b: ^b ->  ^c
        when (NullMap or  ^a) : (static member Operator :  ^a *  ^b ->  ^c)
    val inline ( @?<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullMap or  ^b) : (static member Operator :  ^b *  ^a ->  ^c)
    type NullMap2 =
      class
        static member
          Operator : a:('a option * 'b option) * f:('a -> 'b -> 't) -> 't option
        static member
          Operator : a:('a option * System.Nullable<'b>) * f:('a -> 'b -> 't) ->
                       't option
                       when 'b : (new : unit -> 'b) and 'b : struct and
                            'b :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * 'b option) * f:('a -> 'b -> 't) ->
                       't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member
          Operator : a:('a option * 'b) * f:('a -> 'b -> 't) -> 't option
                       when 'b : null
        static member
          Operator : a:('a * 'b option) * f:('a -> 'b -> 't) -> 't option
                       when 'a : null
        static member
          Operator : a:(System.Nullable<'a> * System.Nullable<'b>) *
                     f:('a -> 'b -> 't) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * 'b) * f:('a -> 'b -> 't) ->
                       't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : null
        static member
          Operator : a:('a * System.Nullable<'b>) * f:('a -> 'b -> 't) ->
                       't option
                       when 'a : null and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType
        static member
          Operator : a:('a * 'b) * f:('a -> 'b -> 't) -> 't option
                       when 'a : null and 'b : null
      end
    val inline ( ||>?@ ) :
      a: ^a -> b: ^b ->  ^c
        when (NullMap2 or  ^a) : (static member Operator :  ^a *  ^b ->  ^c)
    val inline ( @?<|| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullMap2 or  ^b) : (static member Operator :  ^b *  ^a ->  ^c)
    type NullBind =
      class
        static member Operator : a:'a option * f:('a -> 't option) -> 't option
        static member
          Operator : a:'a option * f:('a -> System.Nullable<'t>) -> 't option
                       when 't : (new : unit -> 't) and 't : struct and
                            't :> System.ValueType
        static member
          Operator : a:'a option * f:('a -> 't) -> 't option when 't : null
        static member
          Operator : a:System.Nullable<'a> * f:('a -> 't option) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member
          Operator : a:System.Nullable<'a> * f:('a -> System.Nullable<'t>) ->
                       't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:System.Nullable<'a> * f:('a -> 't) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 't : null
        static member
          Operator : a:'a * f:('a -> 't option) -> 't option when 'a : null
        static member
          Operator : a:'a * f:('a -> System.Nullable<'t>) -> 't option
                       when 'a : null and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:'a * f:('a -> 't) -> 't option
                       when 'a : null and 't : null
      end
    val inline ( |>? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullBind or  ^a) : (static member Operator :  ^a *  ^b ->  ^c)
    val inline ( ?<| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullBind or  ^b) : (static member Operator :  ^b *  ^a ->  ^c)
    type NullBind2 =
      class
        static member
          Operator : a:('a option * 'b option) * f:('a -> 'b -> 't option) ->
                       't option
        static member
          Operator : a:('a option * 'b option) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 't : (new : unit -> 't) and 't : struct and
                            't :> System.ValueType
        static member
          Operator : a:('a option * 'b option) * f:('a -> 'b -> 't) -> 't option
                       when 't : null
        static member
          Operator : a:('a option * System.Nullable<'b>) *
                     f:('a -> 'b -> 't option) -> 't option
                       when 'b : (new : unit -> 'b) and 'b : struct and
                            'b :> System.ValueType
        static member
          Operator : a:('a option * System.Nullable<'b>) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 'b : (new : unit -> 'b) and 'b : struct and
                            'b :> System.ValueType and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:('a option * System.Nullable<'b>) * f:('a -> 'b -> 't) ->
                       't option
                       when 'b : (new : unit -> 'b) and 'b : struct and
                            'b :> System.ValueType and 't : null
        static member
          Operator : a:(System.Nullable<'a> * 'b option) *
                     f:('a -> 'b -> 't option) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * 'b option) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * 'b option) * f:('a -> 'b -> 't) ->
                       't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 't : null
        static member
          Operator : a:('a option * 'b) * f:('a -> 'b -> 't option) -> 't option
                       when 'b : null
        static member
          Operator : a:('a option * 'b) * f:('a -> 'b -> System.Nullable<'t>) ->
                       't option
                       when 'b : null and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:('a option * 'b) * f:('a -> 'b -> 't) -> 't option
                       when 'b : null and 't : null
        static member
          Operator : a:('a * 'b option) * f:('a -> 'b -> 't option) -> 't option
                       when 'a : null
        static member
          Operator : a:('a * 'b option) * f:('a -> 'b -> System.Nullable<'t>) ->
                       't option
                       when 'a : null and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:('a * 'b option) * f:('a -> 'b -> 't) -> 't option
                       when 'a : null and 't : null
        static member
          Operator : a:(System.Nullable<'a> * System.Nullable<'b>) *
                     f:('a -> 'b -> 't option) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * System.Nullable<'b>) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType and
                            't : (new : unit -> 't) and 't : struct and
                            't :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * System.Nullable<'b>) *
                     f:('a -> 'b -> 't) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType and 't : null
        static member
          Operator : a:(System.Nullable<'a> * 'b) * f:('a -> 'b -> 't option) ->
                       't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : null
        static member
          Operator : a:(System.Nullable<'a> * 'b) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : null and
                            't : (new : unit -> 't) and 't : struct and
                            't :> System.ValueType
        static member
          Operator : a:(System.Nullable<'a> * 'b) * f:('a -> 'b -> 't) ->
                       'a option * 'b option
                       when 'a : (new : unit -> 'a) and 'a : struct and
                            'a :> System.ValueType and 'b : null and 't : null
        static member
          Operator : a:('a * System.Nullable<'b>) * f:('a -> 'b -> 't option) ->
                       't option
                       when 'a : null and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType
        static member
          Operator : a:('a * System.Nullable<'b>) *
                     f:('a -> 'b -> System.Nullable<'t>) -> 't option
                       when 'a : null and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType and
                            't : (new : unit -> 't) and 't : struct and
                            't :> System.ValueType
        static member
          Operator : a:('a * System.Nullable<'b>) * f:('a -> 'b -> 't) ->
                       'a option * 'b option
                       when 'a : null and 'b : (new : unit -> 'b) and
                            'b : struct and 'b :> System.ValueType and 't : null
        static member
          Operator : a:('a * 'b) * f:('a -> 'b -> 't option) -> 't option
                       when 'a : null and 'b : null
        static member
          Operator : a:('a * 'b) * f:('a -> 'b -> System.Nullable<'t>) ->
                       't option
                       when 'a : null and 'b : null and 't : (new : unit -> 't) and
                            't : struct and 't :> System.ValueType
        static member
          Operator : a:('a * 'b) * f:('a -> 'b -> 't) -> 't option
                       when 'a : null and 'b : null and 't : null
      end
    val inline ( ||>? ) :
      a: ^a -> b: ^b ->  ^c
        when (NullBind2 or  ^a) : (static member Operator :  ^a *  ^b ->  ^c)
    val inline ( ?<|| ) :
      b: ^a -> a: ^b ->  ^c
        when (NullBind2 or  ^b) : (static member Operator :  ^b *  ^a ->  ^c)
  end

