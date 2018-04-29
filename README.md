# FSharp.Interop.NullOptAble [![NuGet Status](http://img.shields.io/nuget/v/FSharp.Interop.NullOptAble.svg?style=flat)](https://www.nuget.org/packages/FSharp.Interop.NullOptAble/)

Missing OptionBuilder for F# filling the void to interop with  C#'s `?.` usage.
It works with Nulls, Options, Nullables.

CI Builds available: [![MyGet Pre Release](https://img.shields.io/myget/ci-fsharp-optionbuilder/vpre/FSharp.Interop.NullOptAble.svg)](https://www.myget.org/feed/ci-fsharp-optionbuilder/package/nuget/FSharp.Interop.NullOptAble)

Build Statuses:

* Windows: [![Build status](https://ci.appveyor.com/api/projects/status/57yssc1q22p7j0y7/branch/master?svg=true)](https://ci.appveyor.com/project/jbtule/fsharp-interop-nulloptable/branch/master)
* Mac & Linux: [![Build Status](https://travis-ci.org/ekonbenefits/FSharp.Interop.NullOptAble.svg?branch=master)](https://travis-ci.org/ekonbenefits/FSharp.Interop.NullOptAble)

## Basic Info

There are more C# devs relying on the safe nav operator `?.` and so nulls will only get worse on the C# side, making it more likely null's are going to drop out of APIs.

This project creates an `option { }` computational expression and `chooseSeq { }` computational expression that allows binding `'T option`/`'T Nullable`/`'T:null` thus either returns an option or a sequence respectively.

With `chooseSeq` if you `yield!` a sequence it will flatten/collect it. If you want a sequence of sequences use `let! s = nullPossibleSequence;; yield s` or `yield! Some notNullSeq`

### Examples

```fsharp
let x = Nullable(3)
let y = Nullable(3)
option {
    let! x' = x
    let! y' = y
    return (x' + y')
} |> should equal (Some 6)
```
See more examples in [Tests/RealWorld.fs](https://ekonbenefits.github.io/FSharp.Interop.NullOptAble/RealWorld.html).

### Operator Examples

This library also has some operators available when specifically included
```fsharp
using FSharp.Interop.NullOptAble.Operators
```
You can find examples of them in [Tests/RealWorldOperators.fs](https://ekonbenefits.github.io/FSharp.Interop.NullOptAble/RealWorldOperators.html).
