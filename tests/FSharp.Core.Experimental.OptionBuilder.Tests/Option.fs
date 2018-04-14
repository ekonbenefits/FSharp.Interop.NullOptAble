module Tests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Core.Experimental.OptionBuilder

[<Fact>]
let ``Basic Option Unwrap`` () =
    option {
        let! x = Some(3)
        return x + 3
    } |> should equal (Some 6)

[<Fact>]
let ``Basic Option None`` () =
    option {
        let! x = None
        return x + 3
    } |> should equal None

[<Fact>]
let ``Basic Nullable`` () =
    option {
        let! x = Nullable 3
        return x + 4
    } |> should equal (Some 7)

[<Fact>]
let ``Basic None `` () =
    option {
        let! x = Nullable()
        return x + 3
    } |> should equal None

[<Fact>]
let ``Basic Null allowed`` () =
    option {
        let! x = "Hello"
        return x + " World"
    } |> should equal (Some("Hello World"))

[<Fact>]
let ``Basic Null`` () =
    option {
        let! x = null
        return x + " World"
    } |> should equal None

[<Fact>]
let ``Double bind`` () =
    option {
        let! x = Some(1)
        let! y = Some(2)
        return x,y
    } |> should equal (Some(1,2))