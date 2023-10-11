namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class Matrix
{
    private int[,] Data { get; }
    public int RowCount { get; }
    public int ColumnCount { get; }

    public Matrix(int rowCount, int columnCount)
    {
        RowCount = rowCount;
        ColumnCount = columnCount;
        Data = new int[rowCount, columnCount];
    }

    public int GetElement(int rowIndex, int columnIndex)
    {
        throw new NotImplementedException();
    }

    public void SetElement(int rowIndex, int columnIndex, int value)
    {
        throw new NotImplementedException();
    }

    public void SortRow(int rowIndex)
    {
        throw new NotImplementedException();
    }
}