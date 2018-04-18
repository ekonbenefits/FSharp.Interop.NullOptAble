module RealWorldTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Core.Experimental.OptionBuilder
open System.Text

[<Fact>]
let ``Basic nullable math`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    option {
        let! x' = x
        let! y' = y
        return (x' + y')
    } |> should equal (Some 6)

[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set
    
[<Fact>]
let ``Safe Navigation Operator Example`` ()=
    // https://blogs.msdn.microsoft.com/jerrynixon/2014/02/26/at-last-c-is-getting-sometimes-called-the-safe-navigation-operator/
    let parent = Node()
    option {
        let! a = parent.child
        let! b = a.child
        let! c = b.child
        return c
    } |> should equal None
    
[<Fact>] 
let ``Safe Navigation Operator Seq Example`` ()=
    let parents = [
                    Node() //parent
                    Node(Node()) //parent.child
                    Node(Node(Node())) //parent.child.child
                    Node(Node(Node(Node()))) //parent.child.child.child
                  ]
    chooseSeq {
        for parent in parents  do
            let! a = parent.child
            let! b = a.child
            let! c = b.child
            yield c
    } |> Seq.length |> should equal 1

[<Fact>]
let ``RNA transcriptions `` () =
    //test is from exercism 
    //http://exercism.io/exercises/fsharp/rna-transcription/readme
    let toRna (dna: string): string option = 
        let combine (sb:StringBuilder option) =
            let append (c:char) = option {
                    let! sb' = sb
                    return sb'.Append(c)
                }
            function
                    | 'G' -> 'C' |> append
                    | 'C' -> 'G' |> append
                    | 'T' -> 'A' |> append
                    | 'A' -> 'U' |> append
                    | ___ -> None
        option {
            let! dna' = dna //handles if string is null
            let! sb' = dna' |> Seq.fold combine (Some <| StringBuilder())
            return sb'.ToString()
        }
    
    toRna "ACGTGGTCTTAA" |> should equal (Some "UGCACCAGAAUU")

[<Fact>]
let ``rain drops`` () =
    //test if from exercism
    //http://exercism.io/exercises/fsharp/raindrops/readme
    let convert (number: int): string =
        let drop x s = if number % x = 0 then Some s else None
        chooseSeq {
            yield! drop 3 "Pling"
            yield! drop 5 "Plang"
            yield! drop 7 "Plong"
        } |> String.concat ""
          |> function | "" -> string(number)
                      | s -> s
    convert 49 |> should equal "Plong"
    convert 105 |> should equal "PlingPlangPlong"
    convert 52 |> should equal "52"
