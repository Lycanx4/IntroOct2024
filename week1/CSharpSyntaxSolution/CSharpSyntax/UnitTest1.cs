namespace CSharpSyntax;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(1, 1);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    public void CanAddSomeIntegersTogether(int a, int b, int expecting)
    {
        int answer = a + b;

        Assert.Equal(expecting, answer);
    }


}