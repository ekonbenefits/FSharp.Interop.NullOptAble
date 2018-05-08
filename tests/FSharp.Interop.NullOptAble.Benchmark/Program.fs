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

[<RankColumn;MemoryDiagnoser>]
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
        if (this.RefOption() <> this.ValueOption()
                || this.RefOption() <> this.RefOptionInline()
                || this.RefOption() <> this.ValueOptionInline()) then
            failwith "implementations don't match!"

    
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

    [<Benchmark(Baseline = true)>]
    member __.RefOptionInline()=
        let toRna (dna: string): string option = 
            let combine (sb:StringBuilder option) =
                let append (c:char) =
                    match sb with
                    | Some sb' -> sb'.Append(c) |> ignore
                                  sb
                    | None -> sb
                function
                | 'G' -> 'C' |> append
                | 'C' -> 'G' |> append
                | 'T' -> 'A' |> append
                | 'A' -> 'U' |> append
                | ___ -> None
            match dna with
            | null -> None
            | dna' -> match dna' |> Seq.fold combine (Some <| StringBuilder()) with
                      | Some sb' -> sb'.ToString() |> Some
                      | None -> None
        data |> toRna |> Option.defaultValue ""

    [<Benchmark>]
    member __.ValueOptionInline()=
        let toRna (dna: string): string voption = 
            let combine (sb:StringBuilder voption) =
                let append (c:char) =
                    match sb with
                    | VSome sb' -> sb'.Append(c) |> ignore
                                   sb
                    | VNone -> sb
                function
                | 'G' -> 'C' |> append
                | 'C' -> 'G' |> append
                | 'T' -> 'A' |> append
                | 'A' -> 'U' |> append
                | ___ -> VNone
            match dna with
            | null -> VNone
            | dna' -> match dna' |> Seq.fold combine (VSome <| StringBuilder()) with
                      | VSome sb' -> sb'.ToString() |> VSome
                      | VNone -> VNone
        data |> toRna |> ValueOption.defaultValue ""

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<BenchmarkValueOption>() |> ignore
    0 // return an integer exit code
