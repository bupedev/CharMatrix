namespace CharMatrix.Tests;

public class BooleanArrayAccessor : IBitmapAccessor
{
    private readonly bool[,] _array;

    public BooleanArrayAccessor(bool[,] array)
    {
        _array = array ?? throw new ArgumentNullException(nameof(array));
    }

    public bool this[int row, int column] => _array[row, column];

    public int Rows => _array.GetLength(0);

    public int Columns => _array.GetLength(1);
}
