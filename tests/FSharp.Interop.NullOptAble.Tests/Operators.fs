module OperatorTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble.Operators
open FSharp.Interop.NullOptAble.Experimental

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
     |> should equal ValueOption<int>.VNone
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
     |> should equal (VSome 6)

[<Fact>]
let ``Basic Pipe Nullable Null`` () =
    let x = Nullable()
    x
     |>?@ (+) 3
     |> should equal ValueOption<int>.VNone

[<Fact>]
let ``Basic Pipe Null ref Unwrap`` () =
    let x = " World"
    x 
     |>?@ (+) "Hello"
     |> should equal (VSome "Hello World")

[<Fact>]
let ``Basic Pipe Null ref Null`` () =
    let x = null
    x
     |>?@ (+) "Hello"
     |> should equal ValueOption<string>.VNone

[<Fact>]
let ``Basic Pipe Null ref Unwrap left pipe`` () =
    let x = " World"
    (+) "Hello" @?<| x
     |> should equal (VSome "Hello World")

[<Fact>]
let ``Basic Pipe Null ref Null left pipe`` () =
    let x = null
    (+) "Hello" @?<| x
     |> should equal ValueOption<string>.VNone

[<Fact>]
let ``Basic left pipe bind null`` () =
    let x = null
    VSome ?<| x
     |> should equal VNone
    id @?<| x
     |> should equal VNone
[<Fact>]
let ``Basic left pipe bind`` () =
    let x = "Hello"
    Some ?<| x
     |> should equal (VSome "Hello")
    Some @?<| x
     |> should equal (VSome (Some "Hello"))
    id @?<| x
     |> should equal (VSome "Hello")

[<Fact>]
let ``Basic nullable math (terrible)`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    x |>? (fun x'-> y |>?@ (+) x')
    |> should equal (VSome 6)

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
    result |> should equal ValueOption<Node>.VNone

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
    result |> should not' (equal ValueOption<Node>.VNone)
    result |>?@ should not' (equal null) |> ignore
    result |>? navChild |> should equal ValueOption<Node>.VNone


[<Fact>]
let ``Basic map homegenous ||>`` () =
    let y = Some <| Map.ofList [("Here", "Hello World")]
    let x = Some "Here"
    (x,y) ||>? Map.tryFind
          |> should equal (VSome "Hello World")

    (Some("nope"),y) 
        ||>? Map.tryFind
        |> should equal ValueOption<string>.VNone 

[<Fact>]
let ``Basic map heterogenous ||>`` () =
    let y = Some <| Map.ofList [("Here", "Hello World")]
    let x = "Here"
    (x,y) ||>? Map.tryFind
          |> should equal (VSome "Hello World")

    ("nope",y) 
        ||>? Map.tryFind
        |> should equal ValueOption<string>.VNone 

[<Fact>]
let ``Basic nullable math heterogenous`` () =
    let x = Nullable(3)
    let y = Some(3)
    (x,y) ||>?@ ( + )
          |> should equal (VSome 6)