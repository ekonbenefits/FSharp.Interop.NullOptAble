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



#if !disable_nullable
(*** hide ***)
[<Fact>]
let ``Basic nullable math`` () =
    let x = Nullable(3)
    let y = Nullable(3)
    option {
        let! x' = x
        let! y' = y
        return (x' + y')
    } |> should equal (Some 6)
#endif

(*** hide ***)
[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set

(*** hide ***)
type FSharpNode (child:FSharpNode option)=
    new() = new FSharpNode(None)
    member val child:FSharpNode option = child with get,set


(*** hide ***)
[<Fact>]
let ``Safe Navigation Operator Example FSharp option`` ()=
        
    let parent = FSharpNode()
    option {
        let! a = parent.child
        let! b = a.child
        let! c = b.child
        return c
    } |> should equal None

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

(*** hide ***)
type Setup = { ShouldWriteFile:bool}
(**
Guard is just an easy wait for nulloptable binding while dealing with mutations and external state.
*)
[<Fact>]
let ``Guard Example, for dealing with non functional statey things`` () =
    let overrideSetup : Setup option  = None
    let randoFilename = "2713157a-4333-462e-b9e1-c03e0ca6d5af.txt"
    let existsActual = System.IO.File.Exists(randoFilename)
    guard{
        let! setup = overrideSetup
        if setup.ShouldWriteFile then
            use f = System.IO.File.Open(randoFilename, IO.FileMode.CreateNew)  //Never gets run
            ()
    }
    System.IO.File.Exists(randoFilename) |> should equal existsActual

(** 
Modified this recursive prime fucntion from F# docs [example](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences#examples).
*)
[<Fact>] 
let ``IsPrime Example`` ()=
    let isprime n =
        let rec check i =
            n <> 1 && (i > n/2 || (n % i <> 0 && check (i + 1)))
        Option.ofTryTuple (check 2, n)

    let prime = chooseSeq { for n in 1..100 do 
                                let! p = isprime n
                                yield p }

    //verified against list
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
        
    //test case from exercism
    toRna "ACGTGGTCTTAA" |> should equal (Some "UGCACCAGAAUU")

(** 
Solution using `chooseSeq {}` for this [Rain Drops (Fizz buzz) problem from exercism](http://exercism.io/exercises/fsharp/raindrops/readme).
*)
[<Fact>]
let ``rain drops`` () =
    let convert (number: int): string =
        let drop x s = Option.ofTryTuple (number % x = 0, s)
        chooseSeq {
            yield! drop 3 "Pling"
            yield! drop 5 "Plang"
            yield! drop 7 "Plong"
        } |> String.concat ""
          |> function | "" -> string(number)
                      | s -> s

    //test cases from exercism
    convert 49 |> should equal "Plong"
    convert 105 |> should equal "PlingPlangPlong"
    convert 52 |> should equal "52"

(** 
Example using `option {}` for [All Your Base problem from exercism](http://exercism.io/exercises/fsharp/all-your-base/readme).
*)
[<Fact>]
let ``All your Base`` () = 

    let rebase digits inputBase outputBase = 
        let fromBase b digits' =
            let foldToBase10 (acc:int option) d = option {
                if d >= 0 && d < b then
                    let! acc' = acc
                    return (acc' * b + d)
            }
            digits' |> List.fold foldToBase10 (Some 0)
        let toBase b n = option {
            return Seq.initInfinite ignore
                   |> Seq.scan (fun (n', _) _ ->  n' / b, n' % b) (n, 0)
                   |> Seq.pairwise
                   |> Seq.takeWhile (fst >> (fun  (n', _) -> n' > 0))
                   |> Seq.map snd
                   |> Seq.fold (fun acc (_, d) -> d::acc) [] 
                   |> function [] -> [0] | x -> x
        }
        option {
            if inputBase >= 2 && outputBase >= 2 then
                let! base10 =
                    digits
                    |> List.skipWhile ((=) 0) //strip prefixes
                    |> fromBase inputBase
                return! base10 |> toBase outputBase
        }
    
    rebase [1; 1; 2; 0] 3 16 |> should equal (Some [2; 10])
    rebase [1; 2; 1; 0; 1; 0] 2 10 |> should equal None