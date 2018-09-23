# NickBuhro.Translit.Benchmark

Tool for testing performance of NickBuhro.Translit library.

## Test results

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.286 (1803/April2018Update/Redstone4)
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
Frequency=1757813 Hz, Resolution=568.8887 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
| Method | Asset |            Mean |           Error |         StdDev | Scaled | ScaledSD |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|------- |------ |----------------:|----------------:|---------------:|-------:|---------:|----------:|----------:|----------:|-----------:|
| **C2Lv12** |   **Big** |  **4,380,925.8 ns** |  **73,200.0484 ns** | **61,125.3498 ns** |   **1.00** |     **0.00** |  **179.6875** |  **156.2500** |   **93.7500** |   **798475 B** |
| L2Cv12 |   Big | 34,817,752.4 ns | 101,209.2647 ns | 94,671.1998 ns |   7.95 |     0.11 | 5600.0000 | 5600.0000 | 5600.0000 | 22718376 B |
| C2Lv13 |   Big |  4,899,186.0 ns |   3,185.6398 ns |  2,487.1378 ns |   1.12 |     0.01 |  203.1250 |  195.3125 |  195.3125 |   785008 B |
| L2Cv13 |   Big |  5,428,736.2 ns |  42,342.3747 ns | 37,535.4086 ns |   1.24 |     0.02 |  187.5000 |  187.5000 |  187.5000 |   751860 B |
| C2Lv14 |   Big |  1,835,048.6 ns |  10,153.2001 ns |  9,497.3088 ns |   0.42 |     0.01 |  318.3594 |  318.3594 |  318.3594 |  1476064 B |
| L2Cv14 |   Big |  1,991,838.8 ns |   4,312.4902 ns |  3,822.9098 ns |   0.45 |     0.01 |  195.3125 |  195.3125 |  195.3125 |   750480 B |
|        |       |                 |                 |                |        |          |           |           |           |            |
| **C2Lv12** | **Small** |        **948.3 ns** |       **2.9548 ns** |      **2.6194 ns** |   **1.00** |     **0.00** |    **0.1421** |         **-** |         **-** |      **448 B** |
| L2Cv12 | Small |      5,717.4 ns |      14.2676 ns |     13.3459 ns |   6.03 |     0.02 |    0.4501 |         - |         - |     1440 B |
| C2Lv13 | Small |        894.1 ns |       1.3668 ns |      1.2116 ns |   0.94 |     0.00 |    0.1240 |         - |         - |      392 B |
| L2Cv13 | Small |        899.0 ns |       1.3881 ns |      1.2985 ns |   0.95 |     0.00 |    0.0753 |         - |         - |      240 B |
| C2Lv14 | Small |        127.1 ns |       0.3497 ns |      0.3100 ns |   0.13 |     0.00 |    0.1066 |         - |         - |      336 B |
| L2Cv14 | Small |        142.5 ns |       0.2877 ns |      0.2550 ns |   0.15 |     0.00 |    0.0608 |         - |         - |      192 B |

- C2LvXX - cyrillic to latin transliteration;
- L2CvXX - latin to cyrillic transliteration;
- XXXv12 - library version 1.2 (first implementation with replacement dictionaries);
- XXXv13 - library version 1.3 (unpublished impementation based on FSM with preconfigured state transitions);
- XXXv14 - library version 1.4 (code generated FSM on switches).
