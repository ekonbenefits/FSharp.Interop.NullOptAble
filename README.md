# FSharp.Core.Experimental.OptionBuilder [![Build status](https://ci.appveyor.com/api/projects/status/fr0n9r2qucbxrbyi?svg=true)](https://ci.appveyor.com/project/jbtule/fsharp-core-experimental-optionbuilder) [![Build Status](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder.svg?branch=master)](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder)

CI Builds available: [![MyGet Pre Release](https://img.shields.io/myget/ci-fsharp-optionbuilder/vpre/FSharp.Core.Experimental.OptionBuilder.svg)](https://www.myget.org/feed/ci-fsharp-optionbuilder/package/nuget/FSharp.Core.Experimental.OptionBuilder)

Missing OptionBuilder for F# filling the void to interop with  C#'s `?.` usage

There more C# devs rely on `?.` and so nulls will only get worse on the C# side the more often null's are going to appear in APIs.

This project creates an `option { }` computational expression and `chooseSeq { }` computational expression that allows binding `'T option`/`'T Nullable`/`'T:null` and either returns an option or a sequence respectively.

With `chooseSeq` if you `yield!` a sequence it will be flatten/collect it. If you want a sequence of sequences use `let! s = nullPossibleSequence;; yield s` or `yield! Some notNullSeq`


Example:
```
let x = Nullable(3)
  let y = Nullable(3)
  option {
      let! x' = x
      let! y' = y
      return (x' + y')
  } |> should equal (Some 6)
```
See more examples in [Tests/RealWorld.fs](https://github.com/ekonbenefits/FSharp.Core.Experimental.OptionBuilder/blob/master/tests/FSharp.Core.Experimental.OptionBuilder.Tests/RealWorld.fs)
