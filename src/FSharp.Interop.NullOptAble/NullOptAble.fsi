namespace FSharp.Interop.NullOptAble

///**Description**
///
/// Overloads used as the basis for the operators
///
type NullOptAble =
    class
        (* DefaultWith overloads *)

        static member DefaultWith : 'a option * System.Lazy<'a> -> 'a

        static member DefaultWith : System.Nullable<'a> * System.Lazy<'a> -> 'a
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member DefaultWith : 'a * System.Lazy<'a> -> 'a when 'a : null

        (* Map overloads *)

        static member Map : 'a option * ('a -> 'c) -> 'c option
               

        static member Map : System.Nullable<'a> * ('a -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Map : 'a * ('a -> 'c) -> 'c option
                when 'a : null

        (* Map2 overloads *)

        static member Map2 : ('a option * 'b option) * ('a -> 'b -> 'c) -> 'c option
               

        static member Map2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map2 : ('a option * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'b : null

        static member Map2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Map2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null

        static member Map2 : ('a * 'b option) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null

        static member Map2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map2 : ('a * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null
                and  'b : null

        (* Map3 overloads *)

        static member Map3 : ('a option * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
               

        static member Map3 : ('a option * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a option * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'c : null

        static member Map3 : ('a option * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map3 : ('a option * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a option * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null

        static member Map3 : ('a option * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null

        static member Map3 : ('a option * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a option * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null
                and  'c : null

        static member Map3 : (System.Nullable<'a> * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Map3 : (System.Nullable<'a> * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : (System.Nullable<'a> * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null

        static member Map3 : (System.Nullable<'a> * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map3 : (System.Nullable<'a> * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : (System.Nullable<'a> * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Map3 : (System.Nullable<'a> * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null

        static member Map3 : (System.Nullable<'a> * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : (System.Nullable<'a> * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : null

        static member Map3 : ('a * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null

        static member Map3 : ('a * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'c : null

        static member Map3 : ('a * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Map3 : ('a * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Map3 : ('a * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null

        static member Map3 : ('a * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Map3 : ('a * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null 
                and  'c : null

        (* bind overloads *)

        static member Bind : a:'a option * ('a -> 'c option) -> 'c option
               

        static member Bind : a:'a option * ('a -> System.Nullable<'c>) -> 'c option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind : a:'a option * ('a -> 'c) -> 'c option
                when 'c : null

        static member Bind : a:System.Nullable<'a> * ('a -> 'c option) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Bind : a:System.Nullable<'a> * ('a -> System.Nullable<'c>) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind : a:System.Nullable<'a> * ('a -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null

        static member Bind : a:'a * ('a -> 'c option) -> 'c option
                when 'a : null

        static member Bind : a:'a * ('a -> System.Nullable<'c>) -> 'c option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind : a:'a * ('a -> 'c) -> 'c option
                when 'a : null
                and  'c : null

        (* bind2 overloads *)

        static member Bind2 : ('a option * 'b option) * ('a -> 'b -> 'c option) -> 'c option
               

        static member Bind2 : ('a option * 'b option) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a option * 'b option) * ('a -> 'b -> 'c) -> 'c option
                when 'c : null

        static member Bind2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 'c option) -> 'c option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a option * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null

        static member Bind2 : ('a option * 'b) * ('a -> 'b -> 'c option) -> 'c option
                when 'b : null

        static member Bind2 : ('a option * 'b) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a option * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'b : null
                and  'c : null

        static member Bind2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Bind2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : (System.Nullable<'a> * 'b option) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null

        static member Bind2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : (System.Nullable<'a> * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null

        static member Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : (System.Nullable<'a> * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : null

        static member Bind2 : ('a * 'b option) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : null

        static member Bind2 : ('a * 'b option) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a * 'b option) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null
                and  'c : null

        static member Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a * System.Nullable<'b>) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Bind2 : ('a * 'b) * ('a -> 'b -> 'c option) -> 'c option
                when 'a : null
                and  'b : null

        static member Bind2 : ('a * 'b) * ('a -> 'b -> System.Nullable<'c>) -> 'c option
                when 'a : null
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind2 : ('a * 'b) * ('a -> 'b -> 'c) -> 'c option
                when 'a : null
                and  'b : null 
                and  'c : null

        (* bind3 overloads *)

        static member Bind3 : ('a option * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
               

        static member Bind3 : ('a option * 'b option * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'd : null

        static member Bind3 : ('a option * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a option * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType
                and  'd : null

        static member Bind3 : ('a option * 'b option * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'c : null

        static member Bind3 : ('a option * 'b option * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'c : null
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'c : null
                and  'd : null

        static member Bind3 : ('a option * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind3 : ('a option * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'd : null

        static member Bind3 : ('a option * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a option * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a option * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null

        static member Bind3 : ('a option * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : null

        static member Bind3 : ('a option * 'b * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : null

        static member Bind3 : ('a option * 'b * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : null
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null
                and  'd : null

        static member Bind3 : ('a option * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a option * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a option * 'b * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'b : null
                and  'c : null

        static member Bind3 : ('a option * 'b * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'b : null
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a option * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'b : null
                and  'c : null 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'c : null 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null

        static member Bind3 : (System.Nullable<'a> * 'b * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : (System.Nullable<'a> * 'b * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null 
                and  'c : null

        static member Bind3 : (System.Nullable<'a> * 'b * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : (System.Nullable<'a> * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
                and  'b : null
                and  'c : null 
                and  'd : null

        static member Bind3 : ('a * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null

        static member Bind3 : ('a * 'b option * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b option * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'd : null

        static member Bind3 : ('a * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b option * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a * 'b option * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'c : null

        static member Bind3 : ('a * 'b option * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b option * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'c : null 
                and  'd : null

        static member Bind3 : ('a * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType

        static member Bind3 : ('a * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * System.Nullable<'b> * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * System.Nullable<'b> * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType 
                and  'c : null

        static member Bind3 : ('a * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * System.Nullable<'b> * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : (new : unit -> 'b) and 'b : struct and 'b :> System.ValueType
                and  'c : null 
                and  'd : null

        static member Bind3 : ('a * 'b * 'c option) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : null

        static member Bind3 : ('a * 'b * 'c option) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b * 'c option) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null 
                and  'd : null

        static member Bind3 : ('a * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : null 
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType

        static member Bind3 : ('a * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b * System.Nullable<'c>) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null
                and  'c : (new : unit -> 'c) and 'c : struct and 'c :> System.ValueType 
                and  'd : null

        static member Bind3 : ('a * 'b * 'c) * ('a -> 'b -> 'c -> 'd option) -> 'd option
                when 'a : null
                and  'b : null 
                and  'c : null

        static member Bind3 : ('a * 'b * 'c) * ('a -> 'b -> 'c -> System.Nullable<'d>) -> 'd option
                when 'a : null
                and  'b : null
                and  'c : null 
                and  'd : (new : unit -> 'd) and 'd : struct and 'd :> System.ValueType

        static member Bind3 : ('a * 'b * 'c) * ('a -> 'b -> 'c -> 'd) -> 'd option
                when 'a : null
                and  'b : null
                and  'c : null 
                and  'd : null

    end
