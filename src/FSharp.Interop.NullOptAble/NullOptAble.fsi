namespace FSharp.Interop.NullOptAble
  type NullOptAble =
    class
      static member Bind : a:'a option * ('a -> 't option) -> 't option
      static member
        Bind : a:'a option * ('a -> System.Nullable<'t>) -> 't option
                 when 't : (new : unit -> 't) and 't : struct and
                      't :> System.ValueType
      static member
        Bind : a:'a option * ('a -> 't) -> 't option when 't : null
      static member
        Bind : a:System.Nullable<'a> * ('a -> 't option) -> 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType
      static member
        Bind : a:System.Nullable<'a> * ('a -> System.Nullable<'t>) ->
                 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType and 't : (new : unit -> 't) and
                      't : struct and 't :> System.ValueType
      static member
        Bind : a:System.Nullable<'a> * ('a -> 't) -> 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType and 't : null
      static member
        Bind : a:'a * ('a -> 't option) -> 't option when 'a : null
      static member
        Bind : a:'a * ('a -> System.Nullable<'t>) -> 't option
                 when 'a : null and 't : (new : unit -> 't) and 't : struct and
                      't :> System.ValueType
      static member
        Bind : a:'a * ('a -> 't) -> 't option when 'a : null and 't : null
      static member
        Bind2 : ('a option * 'b option) * ('a -> 'b -> 't option) -> 't option
      static member
        Bind2 : ('a option * 'b option) * ('a -> 'b -> System.Nullable<'t>) ->
                  't option
                  when 't : (new : unit -> 't) and 't : struct and
                       't :> System.ValueType
      static member
        Bind2 : ('a option * 'b option) * ('a -> 'b -> 't) -> 't option
                  when 't : null
      static member
        Bind2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 't option) ->
                  't option
                  when 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType
      static member
        Bind2 : ('a option * System.Nullable<'b>) *
                ('a -> 'b -> System.Nullable<'t>) -> 't option
                  when 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType and 't : (new : unit -> 't) and
                       't : struct and 't :> System.ValueType
      static member
        Bind2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 't) ->
                  't option
                  when 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType and 't : null
      static member
        Bind2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 't option) ->
                  't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType
      static member
        Bind2 : (System.Nullable<'a> * 'b option) *
                ('a -> 'b -> System.Nullable<'t>) -> 't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 't : (new : unit -> 't) and
                       't : struct and 't :> System.ValueType
      static member
        Bind2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 't) ->
                  't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 't : null
      static member
        Bind2 : ('a option * 'b) * ('a -> 'b -> 't option) -> 't option
                  when 'b : null
      static member
        Bind2 : ('a option * 'b) * ('a -> 'b -> System.Nullable<'t>) ->
                  't option
                  when 'b : null and 't : (new : unit -> 't) and 't : struct and
                       't :> System.ValueType
      static member
        Bind2 : ('a option * 'b) * ('a -> 'b -> 't) -> 't option
                  when 'b : null and 't : null
      static member
        Bind2 : ('a * 'b option) * ('a -> 'b -> 't option) -> 't option
                  when 'a : null
      static member
        Bind2 : ('a * 'b option) * ('a -> 'b -> System.Nullable<'t>) ->
                  't option
                  when 'a : null and 't : (new : unit -> 't) and 't : struct and
                       't :> System.ValueType
      static member
        Bind2 : ('a * 'b option) * ('a -> 'b -> 't) -> 't option
                  when 'a : null and 't : null
      static member
        Bind2 : (System.Nullable<'a> * System.Nullable<'b>) *
                ('a -> 'b -> 't option) -> 't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : (new : unit -> 'b) and
                       'b : struct and 'b :> System.ValueType
      static member
        Bind2 : (System.Nullable<'a> * System.Nullable<'b>) *
                ('a -> 'b -> System.Nullable<'t>) -> 't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : (new : unit -> 'b) and
                       'b : struct and 'b :> System.ValueType and
                       't : (new : unit -> 't) and 't : struct and
                       't :> System.ValueType
      static member
        Bind2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> 't) ->
                  't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : (new : unit -> 'b) and
                       'b : struct and 'b :> System.ValueType and 't : null
      static member
        Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 't option) ->
                  't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : null
      static member
        Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> System.Nullable<'t>) ->
                  't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : null and
                       't : (new : unit -> 't) and 't : struct and
                       't :> System.ValueType
      static member
        Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 't) -> 't option
                  when 'a : (new : unit -> 'a) and 'a : struct and
                       'a :> System.ValueType and 'b : null and 't : null
      static member
        Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 't option) ->
                  't option
                  when 'a : null and 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType
      static member
        Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> System.Nullable<'t>) ->
                  't option
                  when 'a : null and 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType and 't : (new : unit -> 't) and
                       't : struct and 't :> System.ValueType
      static member
        Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 't) -> 't option
                  when 'a : null and 'b : (new : unit -> 'b) and 'b : struct and
                       'b :> System.ValueType and 't : null
      static member
        Bind2 : ('a * 'b) * ('a -> 'b -> 't option) -> 't option
                  when 'a : null and 'b : null
      static member
        Bind2 : ('a * 'b) * ('a -> 'b -> System.Nullable<'t>) -> 't option
                  when 'a : null and 'b : null and 't : (new : unit -> 't) and
                       't : struct and 't :> System.ValueType
      static member
        Bind2 : ('a * 'b) * ('a -> 'b -> 't) -> 't option
                  when 'a : null and 'b : null and 't : null
      static member DefaultWith : a:'a option * b:System.Lazy<'a> -> 'a
      static member
        DefaultWith : a:System.Nullable<'a> * b:System.Lazy<'a> -> 'a
                        when 'a : (new : unit -> 'a) and 'a : struct and
                             'a :> System.ValueType
      static member DefaultWith : a:'a * b:System.Lazy<'a> -> 'a when 'a : null
      static member Map : a:'a option * ('a -> 't) -> 't option
      static member
        Map : a:System.Nullable<'a> * ('a -> 't) -> 't option
                when 'a : (new : unit -> 'a) and 'a : struct and
                     'a :> System.ValueType
      static member Map : a:'a * ('a -> 't) -> 't option when 'a : null
      static member
        Map2 : ('a option * 'b option) * ('a -> 'b -> 't) -> 't option
      static member
        Map2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 't) ->
                 't option
                 when 'b : (new : unit -> 'b) and 'b : struct and
                      'b :> System.ValueType
      static member
        Map2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 't) ->
                 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType
      static member
        Map2 : ('a option * 'b) * ('a -> 'b -> 't) -> 't option when 'b : null
      static member
        Map2 : ('a * 'b option) * ('a -> 'b -> 't) -> 't option when 'a : null
      static member
        Map2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> 't) ->
                 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType and 'b : (new : unit -> 'b) and
                      'b : struct and 'b :> System.ValueType
      static member
        Map2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 't) -> 't option
                 when 'a : (new : unit -> 'a) and 'a : struct and
                      'a :> System.ValueType and 'b : null
      static member
        Map2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 't) -> 't option
                 when 'a : null and 'b : (new : unit -> 'b) and 'b : struct and
                      'b :> System.ValueType
      static member
        Map2 : ('a * 'b) * ('a -> 'b -> 't) -> 't option
                 when 'a : null and 'b : null
    end