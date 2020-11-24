module OptionTests

open System
open Xunit
open FsUnit.Xunit
open FSharp.Interop.NullOptAble

[<Fact>]
let ``Basic Option Unwrap`` () =
    option {
        let! x = Some(3)
        return x + 3
    } |> should equal (Some 6)

[<Fact>]
let ``Basic Option None`` () =
    option {
        let! x = None
        return x + 3
    } |> should equal None

#if !disable_nullable
[<Fact>]
let ``Basic Nullable`` () =
    option {
        let! x = Nullable 3
        return x + 4
    } |> should equal (Some 7)

[<Fact>]
let ``Basic None `` () =
    option {
        let! x = Nullable()
        return x + 3
    } |> should equal None
#endif
[<Fact>]
let ``Basic Null allowed`` () =
    option {
        let! x = "Hello"
        return x + " World"
    } |> should equal (Some("Hello World"))

[<Fact>]
let ``Basic Null`` () =
    option {
        let! x = null
        return x + " World"
    } |> should equal None

[<Fact>]
let ``Double bind`` () =
    option {
        let! x = Some(1)
        let! y = Some(2)
        return x,y
    } |> should equal (Some(1,2))



type Resource() = 
    let mutable disposed = false
    member __.Disposed() = disposed
    interface System.IDisposable with
        member __.Dispose() =
            disposed <- true


[<Fact>]
let ``Cleaning up disposables when throwing exception`` () =   
    let resource = new Resource()
    let delayedExceptionThrow () =
        option {
            use! d = Some(resource)
            raise <| Exception()
            return d.Disposed()
        } 
    (delayedExceptionThrow >> ignore) |> should throw typeof<Exception>
    resource.Disposed() |> should equal true

#if !disable_nullable
    (*** basic guard mutation ***)
[<Fact>]
let ``Basic Guard don't mutate`` () =
    let mutable test = false
    let x = Nullable<int>();
    let setTrue _ = test <- true
    guard {
        let! x' = x
        
        setTrue x'
    }

    test |> should be False

[<Fact>]
let ``Basic Guard do mutate`` () =
    let mutable test = false
    let x = Nullable<int>(3);
    let setTrue _ = test <- true
    guard {
        let! x' = x
        
        setTrue x'
    }

    test |> should be True
#endif

[<Fact>]
let ``Guard Cleaning up disposables when throwing exception`` () =   
    let resource = new Resource()
    let delayedExceptionThrow () =
        guard {
            use! d = Some(resource)
            raise <| Exception()
        }
    delayedExceptionThrow |> should throw typeof<Exception>
    resource.Disposed() |> should equal true