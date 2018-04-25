module OperatorTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble.Operators

[<Fact>]
let ``Basic Nulled Nullable`` () =
    let x = Nullable()
    let x' = x |?? lazy 6
    x' |> should equal  6

[<Fact>]
let ``Basic not null Nullable`` () =
    let x = Nullable(3)
    let x' = x |?? lazy 6
    x' |> should equal  3


[<Fact>]
let ``Basic not null delay test Nullable`` () =
    let delayRunTest () =
        raise <| Exception("Don't run.")
        6
    let x = Nullable(3)
    let x' = x |?? lazy (delayRunTest ())
    x' |> should equal  3

[<Fact>]
let ``Basic None Option`` () =
    let x = None
    let x' = x |?? lazy 6
    x' |> should equal  6

[<Fact>]
let ``Basic Some Option`` () =
    let x = Some(3)
    let x' = x |?? lazy 6
    x' |> should equal  3

[<Fact>]
let ``Basic Nulled Ref`` () =
    let x:string = null
    let x' = x |?? lazy "okay"
    x' |> should equal "okay"

[<Fact>]
let ``Basic not null ref`` () =
    let x = "original"
    let x' = x |?? lazy "new"
    x' |> should equal "original"

[<Fact>]
let ``Basic Pipe Option Unwrap`` () =
    let x = Some(3)
    x 
     |?|> (+) 3
     |?|> (+) 3
     |?|> should equal 9



[<Fact>]
let ``Basic Pipe Option None`` () =
    let x = None
    x
     |?|> (+) 3
     |> should equal None
[<Fact>]
let ``Basic Pipe Option None Don't Runn`` () =
    let x = None
    x
     |?|> (+) 3
     |?|> (fun _ -> raise (Exception "Don't Run") |> ignore)

[<Fact>]
let ``Basic Pipe Nullable Unwrap`` () =
    let x = Nullable(3)
    x 
     |?|> (+) 3
     |> should equal (Some 6)

[<Fact>]
let ``Basic Pipe Nullable Null`` () =
    let x = Nullable()
    x
     |?|> (+) 3
     |> should equal None

[<Fact>]
let ``Basic Pipe Null ref Unwrap`` () =
    let x = " World"
    x 
     |?|> (+) "Hello"
     |> should equal (Some "Hello World")

[<Fact>]
let ``Basic Pipe Null ref Null`` () =
    let x = null
    x
     |?|> (+) "Hello"
     |> should equal None