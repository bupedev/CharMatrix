namespace CharMatrix.Tests;

public class BooleanArrayAccessorTests
{
    [Fact]
    public void Constructor_WithNullArray_ThrowsException()
    {
        // Assign
        var construct = () =>
        {
            var _ = new BooleanArrayAccessor(null!);
        };

        // Act + Assert
        construct.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void InterfaceProperties_WithValidConstruction_ReturnCorrectValues()
    {
        // Assign
        var accessor = new BooleanArrayAccessor(
            new[,]
            {
                { true, false, true },
                { false, true, false },
            }
        );

        // Act + Assert
        accessor.Rows.Should().Be(2);
        accessor.Columns.Should().Be(3);
        accessor[0, 0].Should().BeTrue();
        accessor[0, 1].Should().BeFalse();
        accessor[0, 2].Should().BeTrue();
        accessor[1, 0].Should().BeFalse();
        accessor[1, 1].Should().BeTrue();
        accessor[1, 2].Should().BeFalse();
    }
}
