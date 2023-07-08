using System.Text;

namespace CharMatrix;

/// <summary>
/// A generator for six-dot braille character matrices. This generator constructs it's matrices using the entire 64
/// unicode character set for six-dot braille as well as:
/// <list type="bullet">
///     <item>' ' (U+0020): The space character.</item>
///     <item>The newline character for the runtime environment (see <see cref="Environment.NewLine"/>)</item>
/// </list>
/// </summary>
public class SixDotBrailleMatrixGenerator
{
    private readonly IBitmapAccessor _bitmapAccessor;

    /// <summary>
    /// Constructs a new <see cref="SixDotBrailleMatrixGenerator"/> instance.
    /// </summary>
    /// <param name="bitmapAccessor">A bitmap accessor for the bitmap from which to generate the character matrix.</param>
    public SixDotBrailleMatrixGenerator(IBitmapAccessor bitmapAccessor)
    {
        _bitmapAccessor = bitmapAccessor;
    }

    /// <summary>
    /// Generates an six-dot braille character matrix from the bitmap provided to the constructor.
    /// </summary>
    /// <returns>A string containing the six-dot braille character matrix.</returns>
    public string Generate()
    {
        var bitmapRows = _bitmapAccessor.Rows;
        var bitmapColumns = _bitmapAccessor.Columns;

        var matrixRows = (int)Math.Ceiling(bitmapRows / 3.0);
        var matrixColumns = (int)Math.Ceiling(bitmapColumns / 2.0);
        var characterMatrix = new byte[matrixRows, matrixColumns];

        for (var row = 0; row < bitmapRows; row++)
        {
            for (var column = 0; column < bitmapColumns; column++)
            {
                var value = _bitmapAccessor[row, column];
                var byteRowIndex = row / 3;
                var byteColumnIndex = column / 2;
                var bitRowIndex = row % 3;
                var bitColumnIndex = column % 2;
                if (value)
                {
                    characterMatrix[byteRowIndex, byteColumnIndex] |= (byte) (1 << (2 * bitRowIndex + bitColumnIndex));
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
                        0b000000 => " ",
                        0b000001 => "⠁",
                        0b000010 => "⠈",
                        0b000011 => "⠉",
                        0b000100 => "⠂",
                        0b000101 => "⠃",
                        0b000110 => "⠊",
                        0b000111 => "⠋",
                        0b001000 => "⠐",
                        0b001001 => "⠑",
                        0b001010 => "⠘",
                        0b001011 => "⠙",
                        0b001100 => "⠒",
                        0b001101 => "⠓",
                        0b001110 => "⠚",
                        0b001111 => "⠛",
                        0b010000 => "⠄",
                        0b010001 => "⠅",
                        0b010010 => "⠌",
                        0b010011 => "⠍",
                        0b010100 => "⠆",
                        0b010101 => "⠇",
                        0b010110 => "⠎",
                        0b010111 => "⠏",
                        0b011000 => "⠔",
                        0b011001 => "⠕",
                        0b011010 => "⠜",
                        0b011011 => "⠝",
                        0b011100 => "⠖",
                        0b011101 => "⠗",
                        0b011110 => "⠞",
                        0b011111 => "⠟",
                        0b100000 => "⠠",
                        0b100001 => "⠡",
                        0b100010 => "⠨",
                        0b100011 => "⠩",
                        0b100100 => "⠢",
                        0b100101 => "⠣",
                        0b100110 => "⠪",
                        0b100111 => "⠫",
                        0b101000 => "⠰",
                        0b101001 => "⠱",
                        0b101010 => "⠸",
                        0b101011 => "⠹",
                        0b101100 => "⠲",
                        0b101101 => "⠳",
                        0b101110 => "⠺",
                        0b101111 => "⠻",
                        0b110000 => "⠤",
                        0b110001 => "⠥",
                        0b110010 => "⠬",
                        0b110011 => "⠭",
                        0b110100 => "⠦",
                        0b110101 => "⠧",
                        0b110110 => "⠮",
                        0b110111 => "⠯",
                        0b111000 => "⠴",
                        0b111001 => "⠵",
                        0b111010 => "⠼",
                        0b111011 => "⠽",
                        0b111100 => "⠶",
                        0b111101 => "⠷",
                        0b111110 => "⠾",
                        0b111111 => "⠿",
                        _ => string.Empty
                    }
                );
            }

            stringBuilder.Append(Environment.NewLine);
        }

        return stringBuilder.ToString();
    }
}


