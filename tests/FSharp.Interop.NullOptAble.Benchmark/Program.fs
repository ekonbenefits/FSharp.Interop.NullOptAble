// Learn more about F# at http://fsharp.org

open System
open System.Text
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open FSharp.Interop.NullOptAble
open FSharp.Interop.NullOptAble.Experimental.ValueOption

type BenchmarkValueOption () =
    let n = 100000;
    let r = Random();
    let nucleo = ['G';'C';'T';'A']
    let data =
        Array.init n (fun _-> nucleo.[r.Next(0, nucleo.Length)])
        |> System.String

    [<Benchmark>]
    member __.RefOption()=
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
        data |> toRna |> Option.defaultValue ""

    [<Benchmark>]
    member __.ValueOption()=
        let toRna (dna: string): string voption = 
            let combine (sb:StringBuilder voption) =
                let append (c:char) = voption {
                        let! sb' = sb
                        return sb'.Append(c)
                    }
                function
                | 'G' -> 'C' |> append
                | 'C' -> 'G' |> append
                | 'T' -> 'A' |> append
                | 'A' -> 'U' |> append
                | ___ -> VNone
            voption {
                let! dna' = dna //handles if string is null
                let! sb' = dna' |> Seq.fold combine (VSome <| StringBuilder())
                return sb'.ToString()
            }
        data |> toRna |> ValueOption.defaultValue ""

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<BenchmarkValueOption>() |> ignore
    0 // return an integer exit code
