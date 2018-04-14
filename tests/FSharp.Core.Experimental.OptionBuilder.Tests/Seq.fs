module Seq

open System
open Xunit
open FsUnit.Xunit
open FSharp.Core.Experimental.OptionBuilder


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
    } |> Seq.length |> should equal 0

[<Fact>]
let ``Basic None empty sequence`` () =
    seqOption {
        yield! None
    } |> Seq.length |> should equal 0


[<Fact>]
let ``Yield Sequence`` () =
    let newSeq = seqOption {
        for i in 1..10 do yield i
    }
    newSeq |> should contain 3
    newSeq |> should contain 4
    newSeq |> Seq.length |> should equal 10
let ``Yield Sequence 2`` () =
    let newSeq = seqOption {
        for i in 1..10 do yield! Some(i)
    }
    newSeq |> should contain 3
    newSeq |> should contain 4
    newSeq |> Seq.length |> should equal 10

let ``Yield Sequence None`` () =
    let newSeq = seqOption {
        for _ in 1..10 do yield! None
    }
    newSeq |> Seq.length |> should equal 0
 
let ``Yield Sequence hardcoded`` () =
    let newSeq = seqOption {
        yield 3
        yield 4
        yield! None
    }
    newSeq |> Seq.length |> should equal 2