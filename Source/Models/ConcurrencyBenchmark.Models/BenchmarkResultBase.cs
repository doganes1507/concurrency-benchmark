namespace ConcurrencyBenchmark.Models;

public abstract class BenchmarkResultBase
{
    public int ThreadCount { get; }
    public long ResultTime { get; }
    
    protected BenchmarkResultBase(int threadCount, long resultTime)
    {
        ThreadCount = threadCount;
        ResultTime = resultTime;
    }
}