using System;
using System.Collections.Generic;
using Xunit;

/*public class EqualExample
{
    [Theory(DisplayName = "Lesson02.Demo03")]
    [InlineData(1, 1, 2)]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(2, 3, 5)]
    public void Demo03_Theory_Test(int num01, int num02, int result)
    {
        Assert.Equal<int>(result, num01 + num02);
    }
}*/
/*public class EqualExample
{
    [Fact(DisplayName = "Lesson02.Demo01")]
    public void Demo01_Fact_Test()
    {
        int num01 = 1;
        int num02 = 2;
        Assert.Equal<int>(3, num01 + num02);
    }

    [Fact(DisplayName = "Lesson02.Demo02", Skip = "Just test skip!")]
    public void Demo02_Fact_Test()
    {
        int num01 = 1;
        int num02 = 2;
        Assert.Equal<int>(5, num01 + num02);
    }
}*/
#region MemberData InputData_Property

public class EqualExample
{
    public static IEnumerable<object[]> InputData_Property
    {
        get
        {
            var driverData = new List<object[]>();
            driverData.Add(new object[] { 1, 1, 2 });
            driverData.Add(new object[] { 1, 2, 3 });
            driverData.Add(new object[] { 2, 4, 6 });
            driverData.Add(new object[] { 3, 4, 7 });
            driverData.Add(new object[] { 4, 4, 8 });
            driverData.Add(new object[] { 5, 6, 11 });
            return driverData;
        }
    }

    [Theory(DisplayName = "Lesson02.Demo04")]
    [MemberData("InputData_Property")]
    public void Demo04_Theory_Test(int num01, int num02, int result)
    {
        Assert.Equal<int>(result, num01 + num02);
    }
    #endregion
}




