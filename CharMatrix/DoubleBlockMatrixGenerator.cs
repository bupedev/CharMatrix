using System.Text;

namespace CharMatrix;

/// <summary>
/// A generator for half-block character matrices. This generator constructs it's matrices using the following
/// characters, spreading a single bit across two characters horizontally:
/// <list type="bullet">
///     <item>' ' (U+0020): The space character.</item>
///     <item>'█' (U+2588): The full block character.</item>
///     <item>The newline character for the runtime environment (see <see cref="Environment.NewLine"/>)</item>
/// </list>
/// </summary>
public class DoubleBlockMatrixGenerator
{
    private readonly IBitmapAccessor _bitmapAccessor;

    /// <summary>
    /// Constructs a new <see cref="DoubleBlockMatrixGenerator"/> instance.
    /// </summary>
    /// <param name="bitmapAccessor">A bitmap accessor for the bitmap from which to generate the character matrix.</param>
    public DoubleBlockMatrixGenerator(IBitmapAccessor bitmapAccessor)
    {
        _bitmapAccessor = bitmapAccessor;
    }

    /// <summary>
    /// Generates a double-block character matrix from the bitmap provided to the constructor.
    /// </summary>
    /// <returns>A string containing the double-block character matrix.</returns>
    public string Generate()
    {
        var bitmapRows = _bitmapAccessor.Rows;
        var bitmapColumns = _bitmapAccessor.Columns;

        var stringBuilder = new StringBuilder();
        for (int row = 0; row < bitmapRows; row++)
        {
            for (int column = 0; column < bitmapColumns; column++)
            {
                var value = _bitmapAccessor[row, column];
                stringBuilder.Append(
                    value switch
                    {
                        true =>  "██",
                        false => "  "
                    }
                );
            }

            stringBuilder.Append(Environment.NewLine);
        }

        return stringBuilder.ToString();
    }
}
