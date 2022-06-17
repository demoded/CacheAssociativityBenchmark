using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class CacheAssociativityBenchmark
{
    private int[] array;

    public CacheAssociativityBenchmark()
    {
        array = new int[128000];
    }
    
    [Benchmark(Baseline = true)]
    public void Slow()
    {
        for (int i = 0; i < 128000; i += 128)
        {
            array[i]++;
        }
    }

    [Benchmark]
    public void Fast()
    {
        for (int i = 0; i < 127000; i+= 127)
        {
            array[i]++;
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}
