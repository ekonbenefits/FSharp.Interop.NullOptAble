#!/bin/sh
#if bin_sh
  # Doing this because arguments can't be used with /usr/bin/env on linux, just mac
  exec fsharpi --exec $0 $*
#endif

open System
open System.IO
open System.Text

type When =
    static member And ([<ParamArray>] ws)  =
            let vals = ws |> Array.toList |> List.choose id
            match vals with
            | v1::v2::v3::[v4] -> 
                sprintf """ when %s
                and  %s
                and  %s 
                and  %s""" v1 v2 v3 v4
            | v1::v2::[v3] -> 
                sprintf """ when %s
                and  %s 
                and  %s""" v1 v2 v3
            | v1::[v2] -> 
                sprintf """ when %s
                and  %s""" v1 v2
            | [v1] -> sprintf " when %s" v1
            | [] -> ""
            | _ -> failwithf "too many args %i." vals.Length

module Run =
    let execute () =
        let basePath = Path.Combine(__SOURCE_DIRECTORY__, "..", "src", "FSharp.Interop.NullOptAble")

        use sigWriter = new StreamWriter(Path.Combine(basePath,"NullOptAble.fsi"), 
                                         append = false, 
                                         encoding =Encoding.UTF8)
        use fsWriter = new StreamWriter(Path.Combine(basePath,"NullOptAble.fs"), 
                                        append = false, 
                                        encoding =Encoding.UTF8)
        let ns = "namespace FSharp.Interop.NullOptAble"
        sigWriter.WriteLine(ns)
        fsWriter.WriteLine(ns)

//Write Type and DefaultWith Overloads
        sigWriter.WriteLine("""
///**Description**
/// Overloads used as the basis for operators
type NullOptAble =
    class
        (* DefaultWith overloads *)

        static member DefaultWith : 'a option * System.Lazy<'a> -> 'a

        static member DefaultWith : System.Nullable<'a> * System.Lazy<'a> -> 'a
                when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType

        static member DefaultWith : 'a * System.Lazy<'a> -> 'a when 'a : null""")

        fsWriter.WriteLine("""
open System

type NullOptAble =
        (* DefaultWith overloads *)

        static member DefaultWith(a: 'a option, b: 'a Lazy) =
            a |> Option.defaultWith b.Force

        static member DefaultWith(a: 'a Nullable, b: 'a Lazy) = 
            a |> Option.ofNullable 
              |> Option.defaultWith b.Force

        static member DefaultWith(a: 'a when 'a:null, b: 'a Lazy) =
            a |> Option.ofObj 
              |> Option.defaultWith b.Force"""
        )

//Write Map Overloads
        let createTypes letter = [ 
            sprintf "%s option" letter,
                None,
                sprintf "%s option" letter,
                None
            sprintf "%s Nullable" letter,
                None,
                sprintf "System.Nullable<%s>" letter,
                Some <| sprintf "%s : (new : unit -> %s) and %s : struct and %s :> System.ValueType" letter letter letter letter
                
            sprintf "%s" letter,
                Some <| sprintf "%s:null" letter,
                sprintf "%s" letter, 
                Some <| sprintf "%s : null" letter
        ]

        let A = "'a"
        let B = "'b"
        let C = "'c"
        let D = "'d"

        let aTypes = createTypes A

        let mapHeader ="""
        (* Map overloads *)"""

        sigWriter.WriteLine(mapHeader)
        fsWriter.WriteLine(mapHeader)

        for a, _, sa, sw in aTypes do
            sigWriter.WriteLine(sprintf """
        static member Map : %s * (%s -> %s) -> %s option
               %s""" sa A C C (When.And(sw)))
            fsWriter.WriteLine(sprintf """
        static member Map(a: %s, f: %s -> %s) =
            option { 
                let! a' = a 
                return f a'
            }""" a A C)
        
//map2
        let bTypes = createTypes B
      
        let map2Header ="""
        (* Map2 overloads *)"""

        sigWriter.WriteLine(map2Header)
        fsWriter.WriteLine(map2Header)

        for a, wa, sa, swa in aTypes do
            for b, wb, sb, swb in bTypes do
                //signature
                sigWriter.WriteLine(
                    sprintf """
        static member Map2 : (%s * %s) * (%s -> %s -> %s) -> %s option
               %s""" sa sb A B C C (When.And(swa,swb)))
                //implementation
                fsWriter.WriteLine(
                    sprintf """
        static member Map2((a: %s, b: %s), f: %s -> %s -> %s) : %s option
               %s =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }""" a b A B C C (When.And(wa,wb)))

//map3
        let cTypes = createTypes C
      
        let map3Header ="""
        (* Map3 overloads *)"""

        sigWriter.WriteLine(map3Header)
        fsWriter.WriteLine(map3Header)

        for a, wa, sa, swa in aTypes do
            for b, wb, sb, swb in bTypes do
                for c, wc, sc, swc in cTypes do
                    //signature
                    sigWriter.WriteLine(
                        sprintf """
        static member Map3 : (%s * %s * %s) * (%s -> %s -> %s -> %s) -> %s option
               %s""" sa sb sc A B C D D (When.And(swa,swb,swc)))
                    //implementation
                    fsWriter.WriteLine(
                        sprintf """
        static member Map3((a: %s, b: %s, c: %s), f: %s -> %s -> %s -> %s) : %s option
               %s =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return f a' b' c'
            }""" a b c A B C D D (When.And(wa,wb,wc)))

//bind
       
        let bindHeader ="""
        (* bind overloads *)"""

        sigWriter.WriteLine(bindHeader)
        fsWriter.WriteLine(bindHeader)

        for a,_,sa,swa in aTypes do
            for c,_,sc,swc in cTypes do
                //Signature
                sigWriter.WriteLine(sprintf """
        static member Bind : a:%s * (%s -> %s) -> %s option
               %s""" sa A sc C (When.And(swa,swc)))
                //Implementation
                fsWriter.WriteLine(
                    sprintf """        
        static member Bind(a: %s, f: %s -> %s) = 
            option {
                let! a' = a
                return! f a'
            }""" a A c)

//Bind2
        let bind2Header ="""
        (* bind2 overloads *)"""

        sigWriter.WriteLine(bind2Header)
        fsWriter.WriteLine(bind2Header)

        for a,wa,sa,swa in aTypes do
            for b,wb,sb,swb in bTypes do
                for c,wc,sc,swc in cTypes do
                    //Signature
                    sigWriter.WriteLine(sprintf """
        static member Bind2 : (%s * %s) * (%s -> %s -> %s) -> %s option
               %s""" sa sb A B sc C (When.And(swa,swb,swc)))
                    //Implementation
                    fsWriter.WriteLine(
                        sprintf """
        static member Bind2((a: %s, b: %s), f: %s -> %s -> %s) : %s option
               %s =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } """ a b A B c C (When.And(wa,wb,wc)))

//Bind3
        let dTypes = createTypes D

        let bind3Header ="""
        (* bind3 overloads *)"""

        sigWriter.WriteLine(bind3Header)
        fsWriter.WriteLine(bind3Header)


        for a,wa,sa,swa in aTypes do
            for b,wb,sb,swb in bTypes do
                for c,wc,sc,swc in cTypes do
                    for d,wd,sd,swd in dTypes do
                        //Signature
                        sigWriter.WriteLine(sprintf """
        static member Bind3 : (%s * %s * %s) * (%s -> %s -> %s -> %s) -> %s option
               %s""" sa sb sc A B C sd D (When.And(swa,swb,swc,swd)))
                        //Implementation
                        fsWriter.WriteLine(sprintf """
        static member Bind3((a: %s, b: %s, c: %s), f: %s -> %s -> %s -> %s) : %s option
               %s =
            option { 
                let! a' = a 
                let! b' = b
                let! c' = c
                return! f a' b' c'
            } """ 
                                              a b c A B C d D (When.And(wa,wb,wc,wd)))

//end
        sigWriter.WriteLine("""
    end""")

Run.execute()