namespace KarateChop.Tests;

public class UnitTest1
{
    [Fact]
    public void TestEmptyArray()
    {   
        var karateChop = new KarateChop();
        Assert.Equal(-1, karateChop.Chop(3, new int[]{}));
    }
    
    [Fact]
    public void TestArraysSize1ElementNotIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(-1, karateChop.Chop(3, new int[]{1}));
    }

    [Fact]
    public void TestArraySize1ElementIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(0, karateChop.Chop(1, new int[]{1}));
    }

    [Fact]
    public void TestArraySize3ElementNotIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(-1, karateChop.Chop(0, new int[]{1, 3, 5}));
        Assert.Equal(-1, karateChop.Chop(2, new int[]{1, 3, 5}));
        Assert.Equal(-1, karateChop.Chop(4, new int[]{1, 3, 5}));
        Assert.Equal(-1, karateChop.Chop(6, new int[]{1, 3, 5}));
    }

    [Fact]
    public void TestArraySize4ElementIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(0, karateChop.Chop(1, new int[]{1, 3, 5, 7}));
        Assert.Equal(1, karateChop.Chop(3, new int[]{1, 3, 5, 7}));
        Assert.Equal(2, karateChop.Chop(5, new int[]{1, 3, 5, 7}));
        Assert.Equal(3, karateChop.Chop(7, new int[]{1, 3, 5, 7}));
    }
        [Fact]
    public void TestArraySize4ElementNotIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(-1, karateChop.Chop(0, new int[]{1, 3, 5, 7}));
        Assert.Equal(-1, karateChop.Chop(2, new int[]{1, 3, 5, 7}));
        Assert.Equal(-1, karateChop.Chop(4, new int[]{1, 3, 5, 7}));
        Assert.Equal(-1, karateChop.Chop(6, new int[]{1, 3, 5, 7}));
        Assert.Equal(-1, karateChop.Chop(8, new int[]{1, 3, 5, 7}));
    }

    [Fact]
    public void TestArraySize3ElementIn()
    {
        var karateChop = new KarateChop();
        Assert.Equal(0, karateChop.Chop(1, new int[]{1, 3, 5}));
        Assert.Equal(1, karateChop.Chop(3, new int[]{1, 3, 5}));
        Assert.Equal(2, karateChop.Chop(5, new int[]{1, 3, 5}));
    }
}