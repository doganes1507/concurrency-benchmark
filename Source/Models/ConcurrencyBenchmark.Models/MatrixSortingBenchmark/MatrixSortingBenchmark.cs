namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixSortingBenchmark : BenchmarkBase
{
    public MatrixGenerator MatrixGenerator { get; }
    
    public MatrixSortingBenchmark(int threadCount, MatrixGenerator matrixGenerator) : base(threadCount)
    {
        MatrixGenerator = matrixGenerator;
    }

    public override MatrixSortingBenchmarkResult RunTest()
    {
        throw new NotImplementedException();
    }
}