namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixSortingBenchmarkResult : BenchmarkResultBase
{
    public int RowCount { get; }
    public int ColumnCount { get; }
    
    public MatrixSortingBenchmarkResult(int threadCount, long resultTime, int rowCount, int columnCount) : base(threadCount, resultTime)
    {
        RowCount = rowCount;
        ColumnCount = columnCount;
    }
}