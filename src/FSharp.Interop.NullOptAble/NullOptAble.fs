namespace FSharp.Interop.NullOptAble

open System
open FSharp.Interop.NullOptAble.Experimental
open FSharp.Interop.NullOptAble
type NullOptAble =
        (* DefaultWith overloads *)
        static member DefaultWith(a: 'a voption, b: 'a Lazy) =
            a |> ValueOption.defaultWith b.Force

        static member DefaultWith(a: 'a option, b: 'a Lazy) =
            a |> ValueOption.ofOption 
              |> ValueOption.defaultWith b.Force

        static member DefaultWith(a: 'a Nullable, b: 'a Lazy) = 
            a |> ValueOption.ofNullable 
              |> ValueOption.defaultWith b.Force

        static member DefaultWith(a: 'a when 'a:null, b: 'a Lazy) =
            a |> ValueOption.ofObj 
              |> ValueOption.defaultWith b.Force

        (* Map overloads *)

        static member Map(a: 'a option, f: 'a -> 'c) =
            voption { 
                let! a' = a 
                return f a'
            }

        static member Map(a: 'a voption, f: 'a -> 'c) =
            voption { 
                let! a' = a 
                return f a'
            }

        static member Map(a: 'a Nullable, f: 'a -> 'c) =
            voption { 
                let! a' = a 
                return f a'
            }

        static member Map(a: 'a, f: 'a -> 'c) =
            voption { 
                let! a' = a 
                return f a'
            }

        (* Map2 overloads *)

        static member Map2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a option, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a voption, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a voption, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a voption, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a voption, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        (* Map3 overloads *)

        static member Map3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a voption, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null 
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        (* bind overloads *)
        
        static member Bind(a: 'a option, f: 'a -> 'c option) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a option, f: 'a -> 'c voption) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a option, f: 'a -> 'c Nullable) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a option, f: 'a -> 'c) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a voption, f: 'a -> 'c option) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a voption, f: 'a -> 'c voption) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a voption, f: 'a -> 'c Nullable) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a voption, f: 'a -> 'c) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c option) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c voption) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c Nullable) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c option) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c voption) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c Nullable) = 
            voption {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c) = 
            voption {
                let! a' = a
                return! f a'
            }

        (* bind2 overloads *)

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b voption), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b voption), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b voption), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c option) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b option), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b option), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b voption), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b voption), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b voption), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b Nullable), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b), f: 'a -> 'b -> 'c option) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a voption, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b voption), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b voption), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b voption), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c voption) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c option) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c option) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b voption), f: 'a -> 'b -> 'c option) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b voption), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b voption), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b voption), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c option) : 'c voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c voption) : 'c voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c) : 'c voption
                when 'a:null
                and  'b:null 
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        (* bind3 overloads *)

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a voption, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'c:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'b:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'b:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b voption, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c voption), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'b:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd voption
                when 'a:null
                and  'b:null 
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd voption) : 'd voption
                when 'a:null
                and  'b:null 
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd voption
                when 'a:null
                and  'b:null 
                and  'c:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd voption
                when 'a:null
                and  'b:null
                and  'c:null 
                and  'd:null =
            voption { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 
