module SeqTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble


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
        for i in 1..10 do
            let! i' = Some(i)
            yield i'
    }
    newSeq |> should contain 3
    newSeq |> should contain 4
    newSeq |> Seq.length |> should equal 10

[<Fact>]
let ``Yield Sequence None`` () =
    let newSeq = chooseSeq {
        for _ in 1..10 do 
            let! i' = None
            yield i'
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
        yield! Some 3
        yield! chooseSeq { yield! Nullable(4) }
        yield! Option.ofTryTuple <| Int32.TryParse("5")
        yield! Option.ofTryTuple <| Int32.TryParse("abfa")
        yield! None
    }
    newSeq |> Seq.length |> should equal 4

[<Fact>]
let ``Rainbow string null Sequence`` () =
    let s:string = null
    let newSeq = chooseSeq {
        yield "1"
        yield! None
        yield! Some "2"
        yield! ["3"]
        yield! chooseSeq { yield! Some("4"); yield! None; yield! Some("5");}
        yield! Option.ofObjWhenNot String.IsNullOrEmpty <| ""
        yield! Option.ofObjWhenNot String.IsNullOrWhiteSpace <| "   "
        yield! Option.ofObjWhenNot String.IsNullOrWhiteSpace <| "6"
        yield! [|"7" ; "8"|] |> NotNullSeq
        yield! Set(["9";"9"])
        yield! ["10"; null] |> Seq.choose Option.ofObj |> NotNullSeq
        let! s' = s
        yield s'
    }
    newSeq |> Seq.length |> should equal 10
    newSeq |> Seq.toList |> should equal ["1" ; "2"; "3"; "4"; "5"; "6" ;"7" ;"8"; "9" ; "10" ]


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


type Resource() = 
    let mutable disposed = false
    member __.Disposed() = disposed
    interface System.IDisposable with
        member __.Dispose() =
            disposed <- true


[<Fact>]
let ``Cleaning up disposables when throwing exception`` () =   
    let resource = new Resource()
    let delayedExceptionThrow () =
        chooseSeq {
            use! d = Some(resource)
            raise <| Exception()
            yield d.Disposed()
        } |> List.ofSeq
    delayedExceptionThrow |> should throw typeof<Exception>
    resource.Disposed() |> should equal true

[<Fact>]
let ``Mutable List Double Check`` () =  
    let mutList = System.Collections.Generic.List<int>()
    mutList.Add(1)
    mutList.Add(2)
    chooseSeq{
        yield! mutList |> NotNullSeq
        yield! mutList |> NotNullSeq
        yield! mutList |> NotNullSeq
    } |> Seq.length |> should equal 6

[<Fact>]
let ``Mutable List Double Check NotNullSeq choose`` () =  
    let mutList = System.Collections.Generic.List<int option>()
    mutList.Add(Some 1)
    mutList.Add(None)
    chooseSeq{
        yield! mutList |> Seq.choose id |> NotNullSeq
        yield! mutList |> Seq.choose id |> NotNullSeq
        yield! mutList |> Seq.choose id |> NotNullSeq
    } |> Seq.length |> should equal 3

[<Fact>]
let ``Stack Safe check`` () =  
    chooseSeq{
       for i in 1..100000 do
          yield i
    } |> Seq.length |> should equal 100000