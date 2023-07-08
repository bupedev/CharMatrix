using System.Text;

namespace CharMatrix;

/// <summary>
/// A generator for spaced dot-block character matrices. This generator constructs it's matrices using the following
/// characters, marking active an inactive bits distinctly and using appropriate width separators:
/// <list type="bullet">
///     <item>' ' (U+0020): The space character.</item>
///     <item>'■' (U+25A0): The black block character.</item>
///     <item>'.' (U+25A0): The period character.</item>
///     <item>The newline character for the runtime environment (see <see cref="Environment.NewLine"/>)</item>
/// </list>
/// </summary>
public class SpacedDotBlockMatrixGenerator
{
    private readonly IBitmapAccessor _bitmapAccessor;

    /// <summary>
    /// Constructs a new <see cref="SpacedDotBlockMatrixGenerator"/> instance.
    /// </summary>
    /// <param name="bitmapAccessor">A bitmap accessor for the bitmap from which to generate the character matrix.</param>
    public SpacedDotBlockMatrixGenerator(IBitmapAccessor bitmapAccessor)
    {
        _bitmapAccessor = bitmapAccessor;
    }

    /// <summary>
    /// Generates a spaced dot-block character matrix from the bitmap provided to the constructor.
    /// </summary>
    /// <returns>A string containing the spaced dot-block character matrix.</returns>
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
                        true =>  '\u25A0',
                        false => '.'
                    }
                );
                if (column < bitmapColumns - 1)
                {
                    stringBuilder.Append(' ');   
                }
            }

            stringBuilder.Append(Environment.NewLine);
        }

        return stringBuilder.ToString();
    }
}
