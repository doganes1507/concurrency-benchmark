namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public static class MatrixParallelSorter
{
    public static void ParallelSort(Matrix matrix, List<MatrixSegment> segments)
    {
        #region InputValidation

        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
        }

        if (segments == null || segments.Count == 0)
        {
            throw new ArgumentException("At least one matrix segment must be provided", nameof(segments));
        }

        #endregion

        var tasks = new List<Task>();

        foreach (var matrixSegment in segments)
        {
            tasks.Add(Task.Run(() => SortSegment(matrix, matrixSegment.StartRow, matrixSegment.EndRow)));
        }
        
        Task.WaitAll(tasks.ToArray());
    }

    private static void SortSegment(Matrix matrix, int startRow, int endRow)
    {
        #region InputVaidation

        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
        }
        
        if (startRow < 0 || startRow >= matrix.RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(startRow), "Start row index must be between 0 and RowCount of the matrix");
        }
        if (endRow < 0 || endRow >= matrix.RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(endRow), "End row index must be between 0 and ColumnCount of the matrix");
        }

        #endregion
        
        for (var i = startRow; i <= endRow; i++)
        {
            matrix.SortRow(i);
        }
    }

    public static List<MatrixSegment> CalculateSegments(int rowCount, int threadCount)
    {
        #region InputValidation

        if (rowCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowCount), "Row count must be greater than 0");
        }

        if (threadCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(threadCount), "Thread count must be greater than 0");
        }

        #endregion

        var segments = new List<MatrixSegment>();

        var rowsPerSegment = rowCount / threadCount;
        var remainingRows = rowCount % threadCount;

        var currentRow = 0;
        for (var i = 0; i < threadCount; i++)
        {
            var segmentRowCount = rowsPerSegment + (i < remainingRows ? 1 : 0);
            var endRow = currentRow + segmentRowCount - 1;

            segments.Add(new MatrixSegment(currentRow, endRow));
            currentRow = endRow + 1;
        }
        
        return segments;
    }
}