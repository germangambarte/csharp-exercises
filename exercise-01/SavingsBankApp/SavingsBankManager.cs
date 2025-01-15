namespace SavingsBankApp;

public class SavingsBankManager
{
    public readonly List<SavingsBank> Accounts = [];

    public void AddAccount(SavingsBank savingsBank)
    {
        Accounts.Add(savingsBank);
    }

    public SavingsBank? GetAccountByCuil(string cuil)
    {
        if (!SavingsBank.ValidateCuil(cuil))
        {
            throw new ArgumentException("Invalid cuil");
        }

        var i = 0;
        while (i < Accounts.Count && Accounts[i].Cuil != cuil)
        {
            i++;
        }

        return Accounts[i].Cuil == cuil ? Accounts[i] : null;
    }

    public int GetAccountsLength()
    {
        return Accounts.Count;
    }
}