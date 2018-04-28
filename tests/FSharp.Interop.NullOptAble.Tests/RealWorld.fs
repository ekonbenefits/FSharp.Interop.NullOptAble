(**
Real World-ish examples
===============
*)

module RealWorldTests
open System
open System.Text
open FSharp.Interop.NullOptAble
(*** hide ***)
open Xunit
open FsUnit.Xunit



(*** HIDE ***)
[<Fact>]
let ``Basic nullable math`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    option {
        let! x' = x
        let! y' = y
        return (x' + y')
    } |> should equal (Some 6)

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
                    Node() //parent = some
                    Node() |> Node //parent.child = some
                    Node() |> Node |> Node //parent.child.child = some
                    Node() |> Node |> Node |> Node //parent.child.child.child = some
                  ]
    chooseSeq {
        for parent in parents  do
            let! a = parent.child
            let! b = a.child
            let! c = b.child
            yield c
    } |> Seq.length |> should equal 1


(** 
Simplifed this Recursive F# docs [example].(https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences)
*)
[<Fact>] 
let ``IsPrime Example`` ()=
    let isprime n =
        let rec check i =
            n <> 1 && (i > n/2 || (n % i <> 0 && check (i + 1)))
        if check 2 then Some n else None

    let prime = chooseSeq { for n in 1..100 do yield! isprime n }
    prime |> Seq.toList
          |> should equal [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 
                            41; 43; 47; 53; 59; 61; 67; 71; 73; 79; 83; 89; 97]

(** 
Solution using `option {}` for this [RNA Transcription problem from exercism](http://exercism.io/exercises/fsharp/rna-transcription/readme).
*)
[<Fact>]
let ``RNA transcriptions `` () =
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

(** 
Solution using `chooseSeq {}` for this [Rain Drops (Fizz buzz) problem from exercism](http://exercism.io/exercises/fsharp/raindrops/readme).
*)
[<Fact>]
let ``rain drops`` () =
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
