namespace FSharp.Interop.NullOptAble
open System

module Option =
    let bind2 binder a b =
        match a,b with
        |Some x, Some y -> binder x y
        | _ -> None

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
        static member Map(a: 'a option, f: 'a -> 't) =
            a |> Option.map f
        static member Map(a: 'a Nullable, f: 'a -> 't) = 
            a |> Option.ofNullable
              |> Option.map f 
        static member Map(a: 'a when 'a:null, f: 'a -> 't) =
            a |> Option.ofObj
              |> Option.map f

        (* Map 2 overloads *)
        static member Map2(a: 'a option * 'b option, f: 'a -> 'b -> 't) =
            a ||> Option.map2 f
        static member Map2(a: 'a option * 'b Nullable, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> x, Option.ofNullable y)
              ||> Option.map2 f
        static member Map2(a: 'a Nullable * 'b option, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> Option.ofNullable x, y)
              ||> Option.map2 f
        static member Map2(a: 'a option * 'b when 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> x, Option.ofObj y)
              ||> Option.map2 f
        static member Map2(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, y)
              ||> Option.map2 f
        static member Map2(a: 'a Nullable * 'b Nullable, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y)
              ||> Option.map2 f
        static member Map2(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y)
              ||> Option.map2 f
        static member Map2(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y)
              ||> Option.map2 f
        static member Map2(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y)
              ||> Option.map2 f

        (* Bind overloads *)
        static member Bind(a: 'a option, f: 'a -> 't option) = 
            a |> Option.bind f
        static member Bind(a: 'a option, f: 'a -> 't Nullable) = 
            let f' = f >> Option.ofNullable 
            a |> Option.bind f'
        static member Bind(a: 'a option, f: 'a -> 't when 't:null) = 
            let f' = f >> Option.ofObj 
            a |> Option.bind f'
        static member Bind(a: 'a Nullable, f: 'a -> 't option) =
            a |> Option.ofNullable 
              |> Option.bind f
        static member Bind(a: 'a Nullable, f: 'a -> 't Nullable) =
            let f' = f >> Option.ofNullable
            a |> Option.ofNullable 
              |> Option.bind f'
        static member Bind(a: 'a Nullable, f: 'a -> 't when 't:null) =
            let f' = f >> Option.ofObj
            a |> Option.ofNullable 
              |> Option.bind f'
        static member Bind(a: 'a when 'a:null, f: 'a -> 't option) =
            a |> Option.ofObj 
              |> Option.bind f
        static member Bind(a: 'a when 'a:null, f: 'a -> 't Nullable) =
            let f' = f >> Option.ofNullable
            a |> Option.ofObj 
              |> Option.bind f'
        static member Bind(a: 'a when 'a:null, f: 'a -> 't when 't:null) =
            let f' = f >> Option.ofObj
            a |> Option.ofObj 
              |> Option.bind f'
        
        (* Bind2 overloads *)
        static member Bind2(a: 'a option * 'b option, f: 'a -> 'b -> 't option) = 
            a ||> Option.bind2 f
        static member Bind2(a: 'a option * 'b option, f: 'a -> 'b -> 't Nullable) = 
            let f' a b = f a b |> Option.ofNullable 
            a ||> Option.bind2 f'
        static member Bind2(a: 'a option * 'b option, f: 'a -> 'b -> 't when 't:null) = 
            let f' a b = f a b |> Option.ofObj 
            a ||> Option.bind2 f'
        static member Bind2(a: 'a option * 'b Nullable, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a option * 'b Nullable, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a option * 'b Nullable, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a Nullable * 'b option, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a Nullable * 'b option, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a Nullable * 'b option, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a option * 'b when 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a option  * 'b when 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a option  * 'b when 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> Option.bind2 f'   
        static member Bind2(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> Option.bind2 f'   
        static member Bind2(a: 'a Nullable * 'b Nullable, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a Nullable * 'b Nullable, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a Nullable * 'b Nullable, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
        static member Bind2(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 
        static member Bind2(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> Option.bind2 f
        static member Bind2(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> Option.bind2 f'
        static member Bind2(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> Option.bind2 f'   