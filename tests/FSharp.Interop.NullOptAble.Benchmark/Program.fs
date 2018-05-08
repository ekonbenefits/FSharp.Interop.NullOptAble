// Learn more about F# at http://fsharp.org

open System
open System.Text
open BenchmarkDotNet.Attributes;
open BenchmarkDotNet.Attributes.Columns
open BenchmarkDotNet.Attributes.Exporters
open BenchmarkDotNet.Attributes.Jobs
open BenchmarkDotNet.Running
open FSharp.Interop.NullOptAble
open FSharp.Interop.NullOptAble.Experimental.ValueOption

[<RPlotExporter; RankColumn;MemoryDiagnoser>]
type BenchmarkValueOption () =

    let r = Random();
    let nucleo = ['G';'C';'T';'A']
    let mutable data = ""

    [<Params(1000, 10_000, 100_000)>]
    member val N = 0 with get,set

    [<GlobalSetup>]
    member this.Setup() =
        data <- Array.init this.N (fun _-> nucleo.[r.Next(0, nucleo.Length)])
                |> System.String

    [<Benchmark(Baseline = true)>]
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
