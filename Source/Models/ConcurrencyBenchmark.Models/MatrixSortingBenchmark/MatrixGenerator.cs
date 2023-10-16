namespace ConcurrencyBenchmark.Models.MatrixSortingBenchmark;

public class MatrixGenerator
{
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    
    public MatrixGenerator(int rowCount, int columnCount)
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
    }

    public Matrix GenerateMatrix()
    {
        var matrix = new Matrix(RowCount, ColumnCount);
        var random = new Random();

        for (var i = 0; i < RowCount; i++)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                matrix.SetElement(i, j, random.Next());
            }
        }
        
        return matrix;
    }
}