``` ini

BenchmarkDotNet=v0.10.14, OS=macOS High Sierra 10.13.4 (17E202) [Darwin 17.5.0]
Intel Core i5-4288U CPU 2.60GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT DEBUG
  DefaultJob : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT


```
|      Method |     Mean |     Error |    StdDev |
|------------ |---------:|----------:|----------:|
|   RefOption | 4.678 ms | 0.0511 ms | 0.0453 ms |
| ValueOption | 7.023 ms | 0.0706 ms | 0.0590 ms |
