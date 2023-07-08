namespace CharMatrix.Tests;

public class DoubleBlockMatrixGeneratorTests
{
    [Fact]
    public void Generate_AppropriatelyConstructedStringReturned()
    {
        // Assign
        var accessor = TestData.GenerateSmileyAccessor();
        var generator = new DoubleBlockMatrixGenerator(accessor);

        // Act
        string result = generator.Generate();
        
        // Assert
        result.Should().Be("    ████████    " + Environment.NewLine +
                           "  ██        ██  " + Environment.NewLine +
                           "██  ██  ██    ██" + Environment.NewLine +
                           "██  ██  ██    ██" + Environment.NewLine +
                           "██        ██  ██" + Environment.NewLine +
                           "██  ██████    ██" + Environment.NewLine +
                           "  ██        ██  " + Environment.NewLine +
                           "    ████████    " + Environment.NewLine);
    }
}