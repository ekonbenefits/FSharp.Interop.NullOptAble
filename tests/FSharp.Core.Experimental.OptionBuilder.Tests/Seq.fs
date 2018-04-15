module SeqTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Core.Experimental.OptionBuilder


[<Fact>]
let ``Basic sequence test`` () =
    chooseSeq {
        yield 3
    } |> should contain 3


let ``Basic sequence test option`` () =
    chooseSeq {
        yield! Some(3)
    } |> should contain 3

[<Fact>]
let ``Basic Empty sequence`` () =
    chooseSeq {
        ()
    } |> Seq.length |> should equal 0

[<Fact>]
let ``Basic None empty sequence`` () =
    chooseSeq {
        yield! None
    } |> Seq.length |> should equal 0


[<Fact>]
let ``Yield Sequence`` () =
    let newSeq = chooseSeq {
        for i in 1..10 do yield i
    }
    newSeq |> should contain 3
    newSeq |> should contain 4
    newSeq |> Seq.length |> should equal 10

[<Fact>]
let ``Yield Sequence 2`` () =
    let newSeq = chooseSeq {
        for i in 1..10 do yield! Some(i)
    }
    newSeq |> should contain 3
    newSeq |> should contain 4
    newSeq |> Seq.length |> should equal 10

[<Fact>]
let ``Yield Sequence None`` () =
    let newSeq = chooseSeq {
        for _ in 1..10 do yield! None
    }
    newSeq |> Seq.length |> should equal 0
 
[<Fact>]
let ``Yield Sequence hardcoded`` () =
    let newSeq = chooseSeq {
        yield 3
        yield 4
        yield! None
    }
    newSeq |> Seq.length |> should equal 2

[<Fact>]
let ``Yield Sequence ever other`` () =
    let newSeq = chooseSeq {
        for i in 1..12 do
            match i % 3 with
                | 0 -> yield! None
                | 1 -> yield! Some(3)
                | 2 -> yield! [1..3]
                | _ -> failwith "nope"
    }
    newSeq |> Seq.length |> should equal 16

[<Fact>]
let ``Rainbow int none Sequence`` () =
    let newSeq = chooseSeq {
        yield 1
        yield! Nullable 2
        yield! Some 3
        yield! [4]
        yield! None
    }
    newSeq |> Seq.length |> should equal 4

[<Fact>]
let ``Rainbow string null Sequence`` () =
    let newSeq = chooseSeq {
        yield "1"
        yield! "2"
        yield! None
        yield! Some "3"
        yield! ["4"]
        let s:string = null
        yield! s
    }
    newSeq |> Seq.length |> should equal 4
    newSeq |> Seq.toList |> should equal ["1"; "2" ; "3"; "4"]


[<Fact>]
let ``Nested for loop`` () =
    let newSeq = chooseSeq {
        for i in 1..10 do
            for j in 1..10 do
                yield i * j
    }
    newSeq |> Seq.length |> should equal 100

[<Fact>]
let ``Delayed execution`` () =
    let milliSeconds = 2000
    let time = DateTime.Now
    let newSeq = chooseSeq {
        for _ in 1..1 do
                yield! Some(DateTime.Now)
    }
    System.Threading.Thread.Sleep(milliSeconds);
    newSeq 
        |> Seq.head
        |> (-) <| time 
        |> should be (greaterThan (TimeSpan.FromMilliseconds(float(milliSeconds))))