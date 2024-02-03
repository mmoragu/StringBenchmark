
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<StringBenchmark>();
    }
}

[MemoryDiagnoser]
public class StringBenchmark
{
    private const string FORMAT_CONT1 = "test{0}{1}";
    private const string FORMAT_CONST= "test{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}";
    [Benchmark]
    public string StringConcatenation1() => "test" + 0 + "test0";

    [Benchmark]
    public string StringFormat1() => string.Format(FORMAT_CONT1, 0, "test0");

    [Benchmark]
    public string StringInterpolation1() => $"test{0}{"test0"}";

    [Benchmark]
    public string FormattableString1() => Format($"test{0}{"test0"}");

    [Benchmark]
    public string StringConcatenation5() => "test" + 0 + "test0" + 1 + "test1" + 2 + "test2" + 3 + "test3" + 4 + "test4";

    [Benchmark]
    public string StringFormat5() => string.Format(FORMAT_CONST, 0, "test0", 1, "test1", 2, "test2", 3, "test3", 4, "test4");

    [Benchmark]
    public string StringInterpolation5() => $"test{0}{"test0"}{1}{"test1"}{2}{"test2"}{3}{"test3"}{4}{"test4"}";

    [Benchmark]
    public string FormattableString5() => Format($"test{0}{"test0"}{1}{"test1"}{2}{"test2"}{3}{"test3"}{4}{"test4"}");



    private static string Format(FormattableString fs)
    {
        return fs.ToString();
    }
}