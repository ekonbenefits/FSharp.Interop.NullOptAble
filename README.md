# FSharp.Core.Experimental.OptionBuilder [![Build status](https://ci.appveyor.com/api/projects/status/fr0n9r2qucbxrbyi?svg=true)](https://ci.appveyor.com/project/jbtule/fsharp-core-experimental-optionbuilder) [![Build Status](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder.svg?branch=master)](https://travis-ci.org/ekonbenefits/FSharp.Core.Experimental.OptionBuilder)


Missing OptionBuilder for F# filling the void to interop with  C#'s ?. usage

There more `?.` are used on the C# side the more often null's are going to appear in APIs.

This project creates and `option { }` cexpr and `chooseSeq { }` expression that unwraps options/nullables/and nulls
