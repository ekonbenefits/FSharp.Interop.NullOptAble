module OperatorTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble.Operators

[<Fact>]
let ``Basic Nulled Nullable`` () =
    let x = Nullable()
    let x' = x |?-> lazy 6
    x' |> should equal  6

[<Fact>]
let ``Basic not null Nullable`` () =
    let x = Nullable(3)
    let x' = x |?-> lazy 6
    x' |> should equal  3


[<Fact>]
let ``Basic not null delay test Nullable`` () =
    let delayRunTest () =
        raise <| Exception("Don't run.")
        6
    let x = Nullable(3)
    let x' = x |?-> lazy (delayRunTest ())
    x' |> should equal  3

[<Fact>]
let ``Basic None Option`` () =
    let x = None
    let x' = x |?-> lazy 6
    x' |> should equal  6

[<Fact>]
let ``Basic Some Option`` () =
    let x = Some(3)
    let x' = x |?-> lazy 6
    x' |> should equal  3

[<Fact>]
let ``Basic Nulled Ref`` () =
    let x:string = null
    let x' = x |?-> lazy "okay"
    x' |> should equal "okay"

[<Fact>]
let ``Basic not null ref`` () =
    let x = "original"
    let x' = x |?-> lazy "new"
    x' |> should equal "original"

[<Fact>]
let ``Basic Pipe Option Unwrap`` () =
    let x = Some(3)
    x 
     |>?@ (+) 3
     |>?@ (+) 3
     |>?@ should equal 9

[<Fact>]
let ``Basic Pipe Option With option Return`` () =
    let x = Some(3)
    x 
     |>? (fun y -> Some (y + 3))
     |>?@ (+) 3
     |>?@ should equal 9

[<Fact>]
let ``Basic All ops`` () =
    let x = Some(3)
    x 
     |>? (fun y -> Some (y + 3))
     |>?@ (+) 3
     |>? (fun _ -> None)
     |>?@ (+) 3
     |?-> lazy 2
     |> should equal 2

[<Fact>]
let ``Basic All ops 2`` () =
    let x = Some(3)
    x 
     |>? (fun y -> Some (y + 3))
     |>?@ (+) 3
     |>?@ (+) 3
     |?-> lazy 2
     |> should equal 12

[<Fact>]
let ``Basic Pipe Option None`` () =
    let x = None
    x
     |>?@ (+) 3
     |> should equal None
[<Fact>]
let ``Basic Pipe Option None Don't Runn`` () =
    let x = None
    x
     |>?@ (+) 3
     |>?@ (fun _ -> raise (Exception "Don't Run") |> ignore)

[<Fact>]
let ``Basic Pipe Nullable Unwrap`` () =
    let x = Nullable(3)
    x 
     |>?@ (+) 3
     |> should equal (Some 6)

[<Fact>]
let ``Basic Pipe Nullable Null`` () =
    let x = Nullable()
    x
     |>?@ (+) 3
     |> should equal None

[<Fact>]
let ``Basic Pipe Null ref Unwrap`` () =
    let x = " World"
    x 
     |>?@ (+) "Hello"
     |> should equal (Some "Hello World")

[<Fact>]
let ``Basic Pipe Null ref Null`` () =
    let x = null
    x
     |>?@ (+) "Hello"
     |> should equal None

[<Fact>]
let ``Basic Pipe Null ref Unwrap left pipe`` () =
    let x = " World"
    (+) "Hello" @?<| x
     |> should equal (Some "Hello World")

[<Fact>]
let ``Basic Pipe Null ref Null left pipe`` () =
    let x = null
    (+) "Hello" @?<| x
     |> should equal None

[<Fact>]
let ``Basic left pipe bind null`` () =
    let x = null
    Some ?<| x
     |> should equal None
    Some @?<| x
     |> should equal None
    id @?<| x
     |> should equal None
[<Fact>]
let ``Basic left pipe bind`` () =
    let x = "Hello"
    Some ?<| x
     |> should equal (Some "Hello")
    Some @?<| x
     |> should equal (Some (Some "Hello"))
    id @?<| x
     |> should equal (Some "Hello")

[<Fact>]
let ``Basic nullable math (terrible)`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    x |>? (fun x'-> y |>?@ (+) x')
    |> should equal (Some 6)

[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set

[<Fact>]
let ``Safe Navigation Operator Example`` ()=
    // https://blogs.msdn.microsoft.com/jerrynixon/2014/02/26/at-last-c-is-getting-sometimes-called-the-safe-navigation-operator/
    let parent = Node()
    let navChild (n:Node) = n.child
    let result = 
        parent
            |>? navChild
            |>? navChild
            |>? navChild
    result |> should equal None

[<Fact>]
let ``Safe Navigation Operator Example found`` ()=
    // https://blogs.msdn.microsoft.com/jerrynixon/2014/02/26/at-last-c-is-getting-sometimes-called-the-safe-navigation-operator/
    let parent = () |> Node |> Node |> Node |> Node
    let navChild (n:Node) = n.child
    let result = 
        parent
            |>? navChild
            |>? navChild
            |>? navChild
    result |> should not' (equal None)
    result |>?@ should not' (equal null) |> ignore
    result |>? navChild |> should equal None


[<Fact>]
let ``Basic map`` () =
    let y = Some <| Map.ofList [("Here", "Hello World")]
    let x = Some "Here"
    (x,y) ||>? Map.tryFind
          |> should equal (Some "Hello World")

    (Some("nope"),y) 
        ||>? Map.tryFind
        |> should equal None     