using CustomStringCollectionLib;

namespace CustomStringCollectionTesting;

public class ACustomStringCollection
{
    [Test]
    public void CanAddNewString()
    {
        var sut = new CustomStringCollection(1);
        sut.Add("Check");
        Assert.That(sut.NumberOfStrings, Is.EqualTo(1));
    }
    [Test]
    public void CanGetAString()
    {
        var sut = new CustomStringCollection(1);
        sut.Add("Check");
        Assert.That(sut.Get(0), Is.EqualTo("Check"));
    }

    [Test]
    public void ShouldThrowExceptionWhenGettingAStringWithBadIndex()
    {
        var sut = new CustomStringCollection(1);
        sut.Add("Check");
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            sut.Get(-1);
        });
    }

    [Test]
    public void CanReportTheStrings()
    {
        var sut = new CustomStringCollection(10);
        sut.Add("Z");
        sut.Add("A");
        sut.Add("B");
        sut.Add("D");
        sut.Add("E");
        Assert.That(sut.ToString(), Is.EqualTo("{Z,A,B,D,E}"));
    }

    //Test the Sort Operation
    [Test]
    public void CanSortStrings()
    {
        var sut = new CustomStringCollection(5);
        sut.Add("Z");
        sut.Add("A");
        sut.Add("B");
        sut.Add("D");
        sut.Add("E");

        sut.Sort();

        Assert.That(sut.Get(0), Is.EqualTo("A"));
        Assert.That(sut.Get(1), Is.EqualTo("B"));
        Assert.That(sut.Get(2), Is.EqualTo("D"));
        Assert.That(sut.Get(3), Is.EqualTo("E"));
        Assert.That(sut.Get(4), Is.EqualTo("Z"));
    }

    //Question 5 100 Statement Coverage

    [Test]
    [Category("100% Statement Coverage")]
    public void ToStringWithTwoStrings()
    {
        var sut = new CustomStringCollection(2);
        sut.Add("A");
        sut.Add("B");
        Assert.That(sut.ToString(), Is.EqualTo("{A,B}"));
    }
   
    // ShouldBeAbleToReportThePositionOfAString
    [Test]
    [Category("100% Statement Coverage")]
    public void ShouldBeAbleToReportThePositionOfAString()
    {
        var sut = new CustomStringCollection(5);
        sut.Add("Z");
        sut.Add("A");
        sut.Add("J");
        sut.Add("D");
    
        sut.Sort();

        //Assert.That(sut.Search("Z"), Is.EqualTo(2));
        Assert.That(sut.Search("Z"), Is.EqualTo(3));

    }

    

}
