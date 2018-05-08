``` ini

BenchmarkDotNet=v0.10.14, OS=macOS High Sierra 10.13.4 (17E202) [Darwin 17.5.0]
Intel Core i5-4288U CPU 2.60GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT DEBUG
  DefaultJob : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT


```
|      Method |       Mean |    Error |    StdDev |     Median |
|------------ |-----------:|---------:|----------:|-----------:|
|   RefOption |   462.5 us | 11.00 us |  14.31 us |   457.5 us |
| ValueOption | 1,253.2 us | 53.83 us | 153.57 us | 1,170.7 us |
