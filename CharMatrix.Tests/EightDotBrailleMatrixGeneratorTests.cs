namespace CharMatrix.Tests;

public class EightDotBrailleMatrixGeneratorTests
{
    [Fact]
    public void Generate_AppropriatelyConstructedStringReturned()
    {
        // Assign
        var accessor = TestData.GenerateSmileyAccessor();
        var generator = new EightDotBrailleMatrixGenerator(accessor);

        // Act
        string result = generator.Generate();
        
        // Assert
        result.Should().Be("⡔⡍⡍⢢" + Environment.NewLine +
                           "⠣⣒⣊⠜" + Environment.NewLine);
    }
}