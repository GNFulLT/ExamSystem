``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1586 (20H2/October2020Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT


```
|                  Method |     Mean |    Error |   StdDev | Rank | Allocated |
|------------------------ |---------:|---------:|---------:|-----:|----------:|
|      GetAccountNullTask | 58.58 ms | 0.454 ms | 0.403 ms |    1 |     32 KB |
|     GetAccountValueTask | 58.78 ms | 0.665 ms | 0.556 ms |    1 |     40 KB |
| GetAccountNullValueTask | 58.84 ms | 0.538 ms | 0.503 ms |    1 |     32 KB |
|          GetAccountTask | 58.96 ms | 0.722 ms | 0.640 ms |    1 |     40 KB |
