module RealWorldOperatorsTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble.Operators
open System.Text


[<Fact>]
let ``Basic nullable math`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    (x,y) ||>?@ ( + )
          |> should equal (Some 6)
let ``Basic concat`` () =
    let x = "Hello "
    let y = "World"
    (x,y) ||>? ( + )
          |> should equal (Some 6)

let ``Basic concat none`` () =
    let x = "Hello "
    let y:string = null
    (x,y) ||>? ( + )
          |> should equal (None)

[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set
    
[<Fact>]
let ``Safe Navigation Operator Example`` ()=
    // https://blogs.msdn.microsoft.com/jerrynixon/2014/02/26/at-last-c-is-getting-sometimes-called-the-safe-navigation-operator/
    let parent = Node()
    let getChild (n:Node) = n.child
    parent 
        |>? getChild 
        |>? getChild
        |>? getChild
        |> should equal None
    
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
        |> Seq.choose id
        |> Seq.length |> should equal 1


[<Fact>]
let ``RNA transcriptions `` () =
    //test is from exercism 
    //http://exercism.io/exercises/fsharp/rna-transcription/readme
    let toRna (dna: string): string option = 
        let combine (sb:StringBuilder option) =
            let append (c:char) = 
                sb |>? (fun (s:StringBuilder) -> s.Append(c))
                
            function
            | 'G' -> 'C' |> append
            | 'C' -> 'G' |> append
            | 'T' -> 'A' |> append
            | 'A' -> 'U' |> append
            | ___ -> None
        
        
        dna
           |>? Seq.fold combine (Some <| StringBuilder())
           |>? string
        
    
    toRna "ACGTGGTCTTAA" |> should equal (Some "UGCACCAGAAUU")
