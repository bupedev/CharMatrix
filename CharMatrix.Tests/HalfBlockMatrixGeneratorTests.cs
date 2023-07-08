namespace CharMatrix.Tests;

public class HalfBlockMatrixGeneratorTests
{
    [Fact]
    public void Generate_AppropriatelyConstructedStringReturned()
    {
        // Assign
        var accessor = new BooleanArrayAccessor(
            new[,]
            {
                { true, true, true, false },
                { true, false, false, true },
                { true, false, false, true },
                { true, true, true, false },
                { true, false, false, true },
                { true, false, false, true },
                { true, true, true, false },
            }
        );
        var generator = new HalfBlockMatrixGenerator(accessor);

        // Act
        string result = generator.Generate();

        // Assert
        result.Should().Be("█▀▀▄" + Environment.NewLine +
                           "█▄▄▀" + Environment.NewLine +
                           "█  █" + Environment.NewLine +
                           "▀▀▀ " + Environment.NewLine);
    }
}
