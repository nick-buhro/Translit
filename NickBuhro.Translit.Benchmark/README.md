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
| Method | Asset |            Mean | Scaled |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|------- |------ |----------------:|-------:|----------:|----------:|----------:|-----------:|
| **C2Lv12** |   **Big** |  **4,380,925 ns** |   **1.00** |  **179** |  **156** |   **93** |   **798475 B** |
| L2Cv12 |   Big | 34,817,752 ns |   7.95 | 5600 | 5600 | 5600 | 22718376 B |
| C2Lv13 |   Big |  4,899,186 ns |   1.12 |  203 |  195 |  195 |   785008 B |
| L2Cv13 |   Big |  5,428,736 ns |   1.24 |  187 |  187 |  187 |   751860 B |
| C2Lv14 |   Big |  1,835,048 ns |   0.42 |  318 |  318 |  318 |  1476064 B |
| L2Cv14 |   Big |  1,991,838 ns |   0.45 |  195 |  195 |  195 |   750480 B |
|        |       |                 |         |           |           |           |            |
| **C2Lv12** | **Small** | **948 ns** |   **1.00** |    **0.1421** |         **-** |         **-** |      **448 B** |
| L2Cv12 | Small |      5,717 ns |   6.03 |    0.4501 |         - |         - |     1440 B |
| C2Lv13 | Small |        894 ns |   0.94 |    0.1240 |         - |         - |      392 B |
| L2Cv13 | Small |        899 ns |   0.95 |    0.0753 |         - |         - |      240 B |
| C2Lv14 | Small |        127 ns |   0.13 |    0.1066 |         - |         - |      336 B |
| L2Cv14 | Small |        142 ns |   0.15 |    0.0608 |         - |         - |      192 B |

- `C2LvXX` - cyrillic to latin transliteration;
- `L2CvXX` - latin to cyrillic transliteration;
- `XXXv12` - library version 1.2 (first implementation with replacement dictionaries);
- `XXXv13` - library version 1.3 (unpublished impementation based on FSM with preconfigured state transitions);
- `XXXv14` - library version 1.4 (code generated FSM on switches).
