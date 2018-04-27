namespace FSharp.Interop.NullOptAble

open System
module Operators =   
    type NullCoalesce =  
        static member Operator(a: 'a option, b: 'a Lazy) =
             a |> Option.defaultWith b.Force
        static member Operator(a: 'a Nullable, b: 'a Lazy) = 
            a |> Option.ofNullable 
              |> Option.defaultWith b.Force
        static member Operator(a: 'a when 'a:null, b: 'a Lazy) =
            a |> Option.ofObj 
              |> Option.defaultWith b.Force
    
    //static generic overloading inlining inspired by http://stackoverflow.com/a/2812306/637783
    let inline opOverloadHelper< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Operator : ^a * ^b -> ^c)> a b = 
                                                ((^t or ^a) : (static member Operator : ^a * ^b -> ^c) (a, b))

    let inline ( |?-> ) a b = opOverloadHelper<NullCoalesce, _, _, _> a b

    type NullMap =  
        static member Operator(a: 'a option, f: 'a -> 't) =
            Option.map f a
        static member Operator(a: 'a Nullable, f: 'a -> 't) = 
            a |> Option.ofNullable
              |> Option.map f 
        static member Operator(a: 'a when 'a:null, f: 'a -> 't) =
            a |> Option.ofObj
              |> Option.map f

    let inline ( |>?@ ) a b = opOverloadHelper<NullMap, _, _, _> a b
    let inline ( @?<| ) b a = opOverloadHelper<NullMap, _, _, _> a b

    type NullMap2 =  
        static member Operator(a: 'a option * 'b option, f: 'a -> 'b -> 't) =
            a ||> Option.map2 f

        static member Operator(a: 'a option * 'b Nullable, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> x, Option.ofNullable y)
              ||> Option.map2 f

        static member Operator(a: 'a Nullable * 'b option, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> Option.ofNullable x, y)
              ||> Option.map2 f

        static member Operator(a: 'a option * 'b when 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> x, Option.ofObj y)
              ||> Option.map2 f

        static member Operator(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, y)
              ||> Option.map2 f

        static member Operator(a: 'a Nullable * 'b Nullable, f: 'a -> 'b -> 't) = 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y)
              ||> Option.map2 f

        static member Operator(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y)
              ||> Option.map2 f

        static member Operator(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y)
              ||> Option.map2 f

        static member Operator(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't) =
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y)
              ||> Option.map2 f

    let inline ( ||>?@ ) a b = opOverloadHelper<NullMap2, _, _, _> a b
    let inline ( @?<|| ) b a = opOverloadHelper<NullMap2, _, _, _> a b

    type NullBind=
        static member Operator(a: 'a option, f: 'a -> 't option) = 
           Option.bind f a
        static member Operator(a: 'a option, f: 'a -> 't Nullable) = 
           let f' = f >> Option.ofNullable 
           Option.bind f' a
        static member Operator(a: 'a option, f: 'a -> 't when 't:null) = 
           let f' = f >> Option.ofObj 
           Option.bind f' a
        static member Operator(a: 'a Nullable, f: 'a -> 't option) =
            a |> Option.ofNullable 
              |> Option.bind f
        static member Operator(a: 'a Nullable, f: 'a -> 't Nullable) =
            let f' = f >> Option.ofNullable
            a |> Option.ofNullable 
              |> Option.bind f'
        static member Operator(a: 'a Nullable, f: 'a -> 't when 't:null) =
            let f' = f >> Option.ofObj
            a |> Option.ofNullable 
              |> Option.bind f'
        static member Operator(a: 'a when 'a:null, f: 'a -> 't option) =
            a |> Option.ofObj 
              |> Option.bind f
        static member Operator(a: 'a when 'a:null, f: 'a -> 't Nullable) =
            let f' = f >> Option.ofNullable
            a |> Option.ofObj 
              |> Option.bind f'
        static member Operator(a: 'a when 'a:null, f: 'a -> 't when 't:null) =
            let f' = f >> Option.ofObj
            a |> Option.ofObj 
              |> Option.bind f'    
    let inline ( |>? ) a b = opOverloadHelper<NullBind, _, _, _> a b
    let inline ( ?<| ) b a = opOverloadHelper<NullBind, _, _, _> a b

    let inline private bind2 binder a b =
            match a,b with
            |Some x, Some y -> binder x y
            | _ -> None

    type NullBind2=
        static member Operator(a: 'a option * 'b option, f: 'a -> 'b -> 't option) = 
           a ||> bind2 f
        static member Operator(a: 'a option * 'b option, f: 'a -> 'b -> 't Nullable) = 
           let f' a b = f a b |> Option.ofNullable 
           a ||> bind2 f'
        static member Operator(a: 'a option * 'b option, f: 'a -> 'b -> 't when 't:null) = 
           let f' a b = f a b |> Option.ofObj 
           a ||> bind2 f'

        static member Operator(a: 'a option * 'b Nullable, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> bind2 f
        static member Operator(a: 'a option * 'b Nullable, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> bind2 f'
        static member Operator(a: 'a option * 'b Nullable, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> x, Option.ofNullable y) 
              ||> bind2 f'
        
        static member Operator(a: 'a Nullable * 'b option, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> bind2 f
        static member Operator(a: 'a Nullable * 'b option, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> bind2 f'
        static member Operator(a: 'a Nullable * 'b option, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, y) 
              ||> bind2 f'

        static member Operator(a: 'a option * 'b when 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> bind2 f
        static member Operator(a: 'a option  * 'b when 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> bind2 f'
        static member Operator(a: 'a option  * 'b when 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> x, Option.ofObj y) 
              ||> bind2 f'   
        static member Operator(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> bind2 f
        static member Operator(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> bind2 f'
        static member Operator(a: 'a * 'b option when 'a:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, y) 
              ||> bind2 f'   
        static member Operator(a: 'a Nullable * 'b Nullable, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> bind2 f
        static member Operator(a: 'a Nullable * 'b Nullable, f: 'a -> 'b ->  't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> bind2 f'
        static member Operator(a: 'a Nullable * 'b Nullable, f: 'a -> 'b ->  't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, Option.ofNullable y) 
              ||> bind2 f'

        static member Operator(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
              ||> bind2 f
        static member Operator(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
              ||> bind2 f'
        static member Operator(a: 'a Nullable * 'b when 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofNullable x, Option.ofObj y) 
        static member Operator(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 
              ||> bind2 f
        static member Operator(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 
              ||> bind2 f'
        static member Operator(a: 'a * 'b Nullable when 'a:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, Option.ofNullable y) 

        static member Operator(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't option) =
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> bind2 f
        static member Operator(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't Nullable) =
            let f' a b = f a b |> Option.ofNullable 
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> bind2 f'
        static member Operator(a: 'a * 'b when 'a:null and 'b:null, f: 'a -> 'b -> 't when 't:null) =
            let f' a b = f a b |> Option.ofObj 
            a ||> (fun x y -> Option.ofObj x, Option.ofObj y) 
              ||> bind2 f'   
    let inline ( ||>? ) a b = opOverloadHelper<NullBind2, _, _, _> a b
    let inline ( ?<|| ) b a = opOverloadHelper<NullBind2, _, _, _> a b