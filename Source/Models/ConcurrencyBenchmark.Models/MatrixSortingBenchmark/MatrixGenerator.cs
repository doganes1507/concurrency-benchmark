namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixGenerator
{
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    
    public MatrixGenerator(int rowCount, int columnCount)
    {
        RowCount = rowCount;
        ColumnCount = columnCount;
    }

    public Matrix GenerateMatrix()
    {
        throw new NotImplementedException();
    }
}