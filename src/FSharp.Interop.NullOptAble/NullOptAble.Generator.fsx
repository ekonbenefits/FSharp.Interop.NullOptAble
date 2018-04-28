#!/bin/sh
#if bin_sh
  # Doing this because arguments can't be used with /usr/bin/env on linux, just mac
  exec fsharpi --exec $0 $*
#endif

open System.IO
open System.Text
open System
open System.ComponentModel
open System.Diagnostics

module Run =
    let execute () =
        use sigWriter = new StreamWriter("NullOptAble.fsi", append = false, encoding =Encoding.UTF8)
        use fsWriter = new StreamWriter("NullOptAble.fs", append = false, encoding =Encoding.UTF8)
        let ns = "namespace FSharp.Interop.NullOptAble"
        sigWriter.WriteLine(ns)
        fsWriter.WriteLine(ns)

//Write Type and DefaultWith Overloads
        sigWriter.WriteLine("""
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

        let aTypes = createTypes A

        let mapHeader ="""
        (* Map overloads *)"""

        sigWriter.WriteLine(mapHeader)
        fsWriter.WriteLine(mapHeader)

        let when' w1 w2 w3 =
            match w1, w2, w3 with
            | Some w1, Some w2, Some w3 -> sprintf " when %s and %s and %s" w1 w2 w3
            | Some w1, Some w2, _
            | Some w1, _,  Some w2
            | _, Some w1, Some w2 -> sprintf " when %s and %s" w1 w2
            | Some w1, _ , _
            | _, Some w1, _
            | _, _ ,Some w1-> sprintf " when %s" w1
            | None, None, None -> ""

        for a, _, sa, sw in aTypes do
            sigWriter.WriteLine(sprintf """
        static member Map : %s * (%s -> %s) -> %s option
               %s""" sa A C C (when' sw None None))
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
               %s""" sa sb A B C C (when' swa swb None))
                //implementation
                fsWriter.WriteLine(
                    sprintf """
        static member Map2((a: %s, b: %s%s), f: %s -> %s -> %s) =
            option { 
                let! a' = a 
                let! b' = b
                return f a' b'
            }""" a b (when' wa wb None) A B C)

//bind
        let tTypes = createTypes C
       
        let bindHeader ="""
        (* bind overloads *)"""

        sigWriter.WriteLine(bindHeader)
        fsWriter.WriteLine(bindHeader)

        for a,_,sa,swa in aTypes do
            for c,_,sc,swc in tTypes do
                //Signature
                sigWriter.WriteLine(sprintf """
        static member Bind : a:%s * (%s -> %s) -> %s option
               %s""" sa A sc C (when' swa swc None))
                //Implementation
                fsWriter.WriteLine(
                    sprintf """        
        static member Bind(a: %s, f: %s -> %s) = 
            option {
                let! a' = a
                return! f a'
            }""" a A c)

//bind2
        let bind2Header ="""
        (* bind2 overloads *)"""

        sigWriter.WriteLine(bind2Header)
        fsWriter.WriteLine(bind2Header)

        for a,wa,sa,swa in aTypes do
            for b,wb,sb,swb in bTypes do
                for c,wc,sc,swc in tTypes do
                    //Signature
                    sigWriter.WriteLine(sprintf """
        static member Bind2 : (%s * %s) * (%s -> %s -> %s) -> %s option
               %s""" sa sb A B sc C (when' swa swb swc))
                    //Implementation
                    fsWriter.WriteLine(
                        sprintf """
        static member Bind2((a: %s, b: %s%s), f: %s -> %s -> %s%s) =
            option { 
                let! a' = a 
                let! b' = b
                return! f a' b'
            } """ a b (when' wa wb None) A B c (when' wc None None) )
        sigWriter.WriteLine("""
    end""")

Run.execute()