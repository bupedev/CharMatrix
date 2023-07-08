using System.Text;

namespace CharMatrix;

/// <summary>
/// A generator for half-block character matrices. This generator constructs it's matrices using the following
/// characters, packing two bits in each character vertically:
/// <list type="bullet">
///     <item>' ' (U+0020): The space character.</item>
///     <item>'▀' (U+2580): The upper half block character.</item>
///     <item>'▄' (U+2584): The lower half block character.</item>
///     <item>'█' (U+2588): The full block character.</item>
///     <item>The newline character for the runtime environment (see <see cref="Environment.NewLine"/>)</item>
/// </list>
/// </summary>
public class HalfBlockMatrixGenerator
{
    private readonly IBitmapAccessor _bitmapAccessor;

    /// <summary>
    /// Constructs a new <see cref="HalfBlockMatrixGenerator"/> instance.
    /// </summary>
    /// <param name="bitmapAccessor">A bitmap accessor for the bitmap from which to generate the character matrix.</param>
    public HalfBlockMatrixGenerator(IBitmapAccessor bitmapAccessor)
    {
        _bitmapAccessor = bitmapAccessor;
    }

    /// <summary>
    /// Generates a half-block character matrix from the bitmap provided to the constructor.
    /// </summary>
    /// <returns>A string containing the half-block character matrix.</returns>
    public string Generate()
    {
        var bitmapRows = _bitmapAccessor.Rows;
        var bitmapColumns = _bitmapAccessor.Columns;

        var matrixRows = (int)Math.Ceiling(bitmapRows / 2.0);
        var matrixColumns = bitmapColumns;
        var characterMatrix = new byte[matrixRows, matrixColumns];

        for (var row = 0; row < bitmapRows; row++)
        {
            for (var column = 0; column < bitmapColumns; column++)
            {
                var value = _bitmapAccessor[row, column];
                var byteIndex = row / 2;
                var bitIndex = row % 2;
                if (value)
                {
                    characterMatrix[byteIndex, column] |= (byte)(1 << bitIndex);
                }
            }
        }

        var stringBuilder = new StringBuilder();
        for (int row = 0; row < matrixRows; row++)
        {
            for (int column = 0; column < matrixColumns; column++)
            {
                var value = characterMatrix[row, column];
                stringBuilder.Append(
                    value switch
                    {
                        0b00 => '\u0020', // ' ' (U+0020)
                        0b01 => '\u2580', // '▀' (U+2580)
                        0b10 => '\u2584', // '▄' (U+2584)
                        0b11 => '\u2588', // '█' (U+2588)
                        _ => string.Empty
                    }
                );
            }

            stringBuilder.Append(Environment.NewLine);
        }

        return stringBuilder.ToString();
    }
}
