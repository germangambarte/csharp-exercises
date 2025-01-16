using exercise_02;
using Xunit.Sdk;

namespace test_exercise_02;

public class UnitTest1
{
    private readonly BillingsManager _billings = new(new decimal[,]
    {
        { 11, 45, 89, 23, 67, 12, 56 },
        { 34, 78, 12, 45, 89, 23, 67 },
        { 90, 34, 78, 12, 45, 89, 23 },
        { 67, 90, 34, 78, 12, 45, 89 },
        { 23, 67, 90, 34, 78, 12, 45 },
    });

    [Fact]
    public void TestAddBilling()
    {
        var expectedBill = _billings.GetBill(1, 1) + 12;
        var newBill = _billings.AddBilling(1, 1, 12);
        Assert.Equal(expectedBill, newBill);
    }

    [Fact]
    public void TestGetBillingByBrand()

    {
        decimal[] entireBillWeek = [11, 45, 89, 23, 67, 12, 56];
        var expectedSum = entireBillWeek.Sum();
        var actualSum = _billings.GetBillingByBrand(1);
        Assert.Equal(expectedSum, actualSum);
    }

    [Fact]
    public void TestGetMaxBillingByDay()
    {
        decimal[] entireBillWeek = [12, 34, 90, 67, 23];
        var expectedMax = entireBillWeek.Max();
        var expectedIndexMax = Array.IndexOf(entireBillWeek, expectedMax);
        var actualResult = _billings.GetMaxBillingByDay(1);
        Assert.Equal((expectedMax, expectedIndexMax), actualResult);
    }

    [Fact]
    public void TestGetMinBillingForWeek()
    {
        var expectedResult = (11M, 0);
        var actualResult = _billings.GetMinBillingForWeek();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void TestGetTotalBilling()
    {
        decimal[] day1 = [11, 45, 89, 23, 67, 12, 56];
        decimal[] day2 = [34, 78, 12, 45, 89, 23, 67];
        decimal[] day3 = [90, 34, 78, 12, 45, 89, 23];
        decimal[] day4 = [67, 90, 34, 78, 12, 45, 89];
        decimal[] day5 = [23, 67, 90, 34, 78, 12, 45];
        var expectedSum = day1.Sum() + day2.Sum() + day3.Sum() + day4.Sum() + day5.Sum();
        var actualSum = _billings.GetTotalBilling();
        Assert.Equal(expectedSum, actualSum);

    }
}