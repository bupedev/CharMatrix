namespace CharMatrix.Tests;

static internal class TestData
{
    public static IBitmapAccessor GenerateSmileyAccessor()
    {
        var _ = false;
        var x = true;
        return new BooleanArrayAccessor(
            new[,]
            {
                { _, _, x, x, x, x, _, _ },
                { _, x, _, _, _, _, x, _ },
                { x, _, x, _, x, _, _, x },
                { x, _, x, _, x, _, _, x },
                { x, _, _, _, _, x, _, x },
                { x, _, x, x, x, _, _, x },
                { _, x, _, _, _, _, x, _ },
                { _, _, x, x, x, x, _, _ },
            }
        );
    }
}