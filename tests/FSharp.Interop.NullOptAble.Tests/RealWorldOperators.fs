(**
Real World-ish examples using the Operators
===============
*)
module RealWorldOperatorsTests

open System
open System.Text
open FSharp.Interop.NullOptAble.Operators
open FSharp.Interop.NullOptAble.Experimental
(*** hide ***)
open Xunit
open FsUnit.Xunit

(**
DefaultWith operator. Handy abbreviation of matching a null/nullable/none case.
*)
[<Fact>] 
let ``null defaultWith`` () =
    let x = Nullable()
    x |?-> lazy 3 |> should equal 3
let `` defaultWith not called if not needed`` () =
    let x = Nullable(3)
    x |?-> lazy (failwith "doesn't get run") |> should equal 3

(**
Binding operator means function isn't applied if a `None` parameter. 
However I suggest using [computational expressions](https://ekonbenefits.github.io/FSharp.Interop.NullOptAble/RealWorld.html) over these bind operators in most cases.
*)
[<Fact>]          
let ``Basic concat`` () =
    let x = "Hello "
    let y = "World"
    (x,y) ||>? ( + ) |> should equal (VSome "Hello World")
[<Fact>]
let ``Basic concat none`` () =
    let x = "Hello "
    let y:string = null
    (x,y) ||>? ( + ) |> should equal (ValueOption<string>.VNone)

(**
Binding doesn't work if function returns a non-`_:null or Nullable<_> or Option<_>`. You can use map operator instead `|>?@` but becareful don't use it on something that could be null.
*)
[<Fact>]
let ``Basic nullable math`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    (x,y) ||>?@ ( + ) |> should equal (VSome 6)

(*** hide ***)
[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set
    

(**
Doing the things found in this [MSDN Blog Post did with the Safe Nav operator](https://blogs.msdn.microsoft.com/jerrynixon/2014/02/26/at-last-c-is-getting-sometimes-called-the-safe-navigation-operator/)

*)
[<Fact>]
let ``Safe Navigation Operator Example`` ()=
    let getChild (n:Node) = n.child
    let parent = Node()
    parent 
        |>? getChild 
        |>? getChild
        |>? getChild
        |> should equal ValueOption<Node>.VNone

[<Fact>] 
let ``Safe Navigation Operator Seq Example`` ()=
    let getChild (n:Node) = n.child
    let parents = [
                    Node() //parent = some
                    Node() |> Node //parent.child = some
                    Node() |> Node |> Node //parent.child.child = some
                    Node() |> Node |> Node |> Node //parent.child.child.child = some
                  ]
    seq {
        for parent in parents  do
            yield parent 
                |>? getChild 
                |>? getChild
                |>? getChild
    } 
        |> Seq.choose Option.ofValueOption
        |> Seq.length |> should equal 1


(** 
Solution using `|>?` for this [RNA Transcription problem from exercism](http://exercism.io/exercises/fsharp/rna-transcription/readme).

**Note**: `|>? fun (s:StringBuilder) ->` This is because `|>?` needs argument for lambda overloads to work.
*)
[<Fact>]
let ``RNA transcriptions `` () =
    let toRna (dna: string): string voption = 
        let combine (sb:StringBuilder voption) =
            let append (c:char) = 
                sb |>? (fun (s:StringBuilder) -> s.Append(c))       
            function
            | 'G' -> 'C' |> append
            | 'C' -> 'G' |> append
            | 'T' -> 'A' |> append
            | 'A' -> 'U' |> append
            | ___ -> VNone
        dna
           |>? Seq.fold combine (VSome <| StringBuilder())
           |>? string

    //test case from exercism
    toRna "ACGTGGTCTTAA" |> should equal (VSome "UGCACCAGAAUU")
