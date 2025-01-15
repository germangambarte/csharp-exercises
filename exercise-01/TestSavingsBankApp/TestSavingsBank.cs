using SavingsBankApp;

namespace TestSavingsBankApp;

public class TestSavingsBank
{
    private readonly SavingsBank _firstSavingsBank = new(
        accountId: "1",
        cuil: "20123456786",
        firstName: "German",
        lastName: "Gambarte",
        balance: 123
    );

    private readonly SavingsBank _secondSavingsBank = new(
        accountId: "2",
        cuil: "20123456788",
        firstName: "Micaela",
        lastName: "Farias",
        balance: 100
    );

    [Fact]
    public void TestExtract()
    {
        const int toExtract = 100;
        var expectedBalance = _firstSavingsBank.Balance - toExtract;
        var actualBalance = _firstSavingsBank.Extract(toExtract);
        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void TestExtractThrowsException()
    {
        decimal toExtract = 0;
        Assert.Throws<ArgumentException>(() => _firstSavingsBank.Extract(toExtract));
        toExtract = _firstSavingsBank.Balance + 100;
        Assert.Throws<ArgumentException>(() => _firstSavingsBank.Extract(toExtract));
    }

    [Fact]
    public void TestDeposit()
    {
        const int toDeposit = 100;
        var expectedBalance = _firstSavingsBank.Balance + toDeposit;
        var actualBalance = _firstSavingsBank.Deposit(toDeposit);
        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void TestDepositThrowsException()
    {
        decimal toDeposit = 0;
        Assert.Throws<ArgumentException>(() => _firstSavingsBank.Deposit(toDeposit));
    }


    [Fact]
    public void TestValidateCuil()
    {
        Assert.True(SavingsBank.ValidateCuil(_firstSavingsBank.Cuil));
        Assert.False(SavingsBank.ValidateCuil(_secondSavingsBank.Cuil));
    }
}