using SavingsBankApp;

namespace TestSavingsBankApp;

public class TestSavingsBankManager
{
    private readonly SavingsBankManager _accounts = new SavingsBankManager();

    private readonly SavingsBank _firstSavingsBank = new(
        accountId: "1",
        cuil: "20123456786",
        firstName: "German",
        lastName: "Gambarte",
        balance: 123
    );

    private readonly SavingsBank _secondSavingsBank = new(
        accountId: "2",
        cuil: "20410266928",
        firstName: "Micaela",
        lastName: "Farias",
        balance: 100
    );

    private readonly SavingsBank _thirdSavingsBank = new(
        accountId: "3",
        cuil: "20060850910",
        firstName: "Juan",
        lastName: "Gambarte",
        balance: 100
    );


    [Fact]
    public void TestAddAccount()
    {
        _accounts.AddAccount(_firstSavingsBank);
        _accounts.AddAccount(_secondSavingsBank);
        _accounts.AddAccount(_thirdSavingsBank);

        Assert.Equal(3, _accounts.GetAccountsLength());
    }

    [Fact]
    public void TestGetAccountByCuil()
    {
        _accounts.AddAccount(_firstSavingsBank);
        _accounts.AddAccount(_secondSavingsBank);
        _accounts.AddAccount(_thirdSavingsBank);

        var account = _accounts.GetAccountByCuil(_firstSavingsBank.Cuil);
        Assert.Equal(_firstSavingsBank, account);
    }
}