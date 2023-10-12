using System.Diagnostics;

namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixSortingBenchmark : BenchmarkBase
{
    public MatrixGenerator MatrixGenerator { get; }

    public MatrixSortingBenchmark(int threadCount, MatrixGenerator matrixGenerator) : base(threadCount)
    {
        #region InputValidation

        if (threadCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(threadCount), "Thread count must be greater than 0");
        }

        if (matrixGenerator == null)
        {
            throw new ArgumentNullException(nameof(matrixGenerator), "MatrixGenerator must not be null");
        }

        if (threadCount > matrixGenerator.RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(threadCount),
                "Thread count cannot exceed the number of rows in the matrix");
        }

        #endregion

        MatrixGenerator = matrixGenerator;
    }

    public override MatrixSortingBenchmarkResult RunTest()
    {
        var matrix = MatrixGenerator.GenerateMatrix();
        var segments = MatrixParallelSorter.CalculateSegments(matrix.RowCount, ThreadCount);

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        MatrixParallelSorter.ParallelSort(matrix, segments);
        stopwatch.Stop();

        return new MatrixSortingBenchmarkResult
        (
            ThreadCount,
            stopwatch.ElapsedMilliseconds,
            matrix.RowCount,
            matrix.ColumnCount
        );
    }
}