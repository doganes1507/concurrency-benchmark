namespace ConcurrencyBenchmark.Models;

public abstract class BenchmarkBase
{
    public int ThreadCount { get; set; }
    
    protected BenchmarkBase(int threadCount)
    {
        ThreadCount = threadCount;
    }
    
    public abstract BenchmarkResultBase RunTest();
}