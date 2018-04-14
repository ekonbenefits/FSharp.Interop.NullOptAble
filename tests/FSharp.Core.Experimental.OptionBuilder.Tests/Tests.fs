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
let ``Basic sequence test`` () =
    seqOption {
        yield 3
    } |> should contain 3


let ``Basic sequence test option`` () =
    seqOption {
        yield! Some(3)
    } |> should contain 3

[<Fact>]
let ``Basic Empty sequence`` () =
    seqOption {
        ()
    } |> should equal (Seq.empty)

[<Fact>]
let ``Basic None empty sequence`` () =
    seqOption {
        yield! None
    } |> should equal (Seq.empty)