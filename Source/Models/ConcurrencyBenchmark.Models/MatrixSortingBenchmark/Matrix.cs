namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class Matrix
{
    private int[,] Data { get; }
    public int RowCount { get; }
    public int ColumnCount { get; }

    public Matrix(int rowCount, int columnCount)
    {
        #region InputVaidation

        if (rowCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowCount), "Row count must be greater than 0");
        }
        if (columnCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnCount), "Column count must be greater than 0");
        }

        #endregion
        
        RowCount = rowCount;
        ColumnCount = columnCount;
        Data = new int[rowCount, columnCount];
    }

    public int GetElement(int rowIndex, int columnIndex)
    {
        #region InputVaidation

        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index must be between 0 and RowCount of the matrix");
        }
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex), "Column index must be between 0 and ColumnCount of the matrix");
        }

        #endregion
        
        return Data[rowIndex, columnIndex];
    }

    public void SetElement(int rowIndex, int columnIndex, int value)
    {
        #region InputVaidation

        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index must be between 0 and RowCount of the matrix");
        }
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex), "Column index must be between 0 and ColumnCount of the matrix");
        }

        #endregion
        
        Data[rowIndex, columnIndex] = value;
    }

    public void SortRow(int rowIndex)
    {
        #region InputVaidation

        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index must be between 0 and RowCount of the matrix");
        }

        #endregion
        
        for (var i = 0; i < ColumnCount - 1; i++)
        {
            for (var j = 0; j < ColumnCount - i - 1; j++)
            {
                if (Data[rowIndex, j] > Data[rowIndex, j + 1])
                {
                    (Data[rowIndex, j], Data[rowIndex, j + 1]) = (Data[rowIndex, j + 1], Data[rowIndex, j]);
                }
            }
        }
    }
}