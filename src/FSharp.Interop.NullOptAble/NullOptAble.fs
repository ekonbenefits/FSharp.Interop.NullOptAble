namespace FSharp.Interop.NullOptAble

open System

type NullOptAble =
        (* DefaultWith overloads *)

        static member DefaultWith(a: 'a option, b: 'a Lazy) =
            a |> Option.defaultWith b.Force

        static member DefaultWith(a: 'a Nullable, b: 'a Lazy) = 
            a |> Option.ofNullable 
              |> Option.defaultWith b.Force

        static member DefaultWith(a: 'a when 'a:null, b: 'a Lazy) =
            a |> Option.ofObj 
              |> Option.defaultWith b.Force

        (* Map overloads *)

        static member Map(a: 'a option, f: 'a -> 'c) =
            option { 
                let! a' = a 
                return f a'
            }

        static member Map(a: 'a Nullable, f: 'a -> 'c) =
            option { 
                let! a' = a 
                return f a'
            }

        static member Map(a: 'a, f: 'a -> 'c) =
            option { 
                let! a' = a 
                return f a'
            }

        (* Map2 overloads *)

        static member Map2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        static member Map2((a: 'a, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }

        (* Map3 overloads *)

        static member Map3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        static member Map3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null 
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }

        (* bind overloads *)
        
        static member Bind(a: 'a option, f: 'a -> 'c option) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a option, f: 'a -> 'c Nullable) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a option, f: 'a -> 'c) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c option) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c Nullable) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a Nullable, f: 'a -> 'c) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c option) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c Nullable) = 
            option {
                let! a' = a
                return! f a'
            }
        
        static member Bind(a: 'a, f: 'a -> 'c) = 
            option {
                let! a' = a
                return! f a'
            }

        (* bind2 overloads *)

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c option) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c option) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a option, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c option) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c option
                =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c option) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a Nullable, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c option) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c Nullable) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b option), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c option) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c Nullable) : 'c option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b Nullable), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c option) : 'c option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c Nullable) : 'c option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        static member Bind2((a: 'a, b: 'b), f: 'a -> 'b -> 'c) : 'c option
                when 'a:null
                and  'b:null 
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } 

        (* bind3 overloads *)

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a option, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'c:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'c:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'b:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a Nullable, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'b:null
                and  'c:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b option, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'c:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b Nullable, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'c:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c option), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null
                and  'b:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c Nullable), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd option) : 'd option
                when 'a:null
                and  'b:null 
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd Nullable) : 'd option
                when 'a:null
                and  'b:null 
                and  'c:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 

        static member Bind3((a: 'a, b: 'b, c: 'c), f: 'a -> 'b -> 'c -> 'd) : 'd option
                when 'a:null
                and  'b:null
                and  'c:null 
                and  'd:null =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } 
