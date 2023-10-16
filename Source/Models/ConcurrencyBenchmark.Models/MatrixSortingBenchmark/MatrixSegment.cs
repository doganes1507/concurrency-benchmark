namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixSegment
{
    public int StartRow { get; }
    public int EndRow { get; }
    
    public MatrixSegment(int startRow, int endRow)
    {
        StartRow = startRow;
        EndRow = endRow;
    }
}