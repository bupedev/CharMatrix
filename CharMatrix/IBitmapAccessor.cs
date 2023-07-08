namespace CharMatrix;

/// <summary>
/// An interface for accessing the values of a bitmap. This interface should be implemented by for consumers of the
/// character matrix generators this package provides. At this time, all bitmaps are assumed to be binary/monochrome.
/// </summary>
public interface IBitmapAccessor
{
    /// <summary>
    /// Gets the value at the specified row and column of the bitmap.
    /// </summary>
    /// <param name="row">The row of the value to get.</param>
    /// <param name="column">The column of the value to get.</param>
    bool this[int row, int column] { get; }
    
    /// <summary>
    /// The number of rows in the bitmap.
    /// </summary>
    int Rows { get; }
    
    /// <summary>
    /// The number of columns in the bitmap.
    /// </summary>
    int Columns { get; }
}