# FSharp.Core.Experimental.OptionBuilder [![Build status](https://ci.appveyor.com/api/projects/status/fr0n9r2qucbxrbyi?svg=true)](https://ci.appveyor.com/project/jbtule/fsharp-core-experimental-optionbuilder) [![Build Status](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder.svg?branch=master)](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder)

Missing OptionBuilder for F# filling the void to interop with  C#'s ?. usage

There more C# devs rely on `?.` and so nulls will only get worse on the C# side the more often null's are going to appear in APIs.

This project creates an `option { }` computational expression and `chooseSeq { }` computational expression that allows binding `'T option`/`'T Nullable`/`'T:null` and either returns an option or a sequence respectively.

With `chooseSeq` if you `yield!` a sequence it will be flatten/collect it. If you want a sequence of sequences use `let! s = nullPossibleSequence;; yield s` or `yield! Some notNullSeq`