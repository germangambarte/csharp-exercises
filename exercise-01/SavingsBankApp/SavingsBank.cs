namespace SavingsBankApp;

public class SavingsBank
{
    public string AccountId { get; private set; }
    public string Cuil { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public decimal Balance { get; private set; }

    public SavingsBank(string accountId, string cuil, string firstName, string lastName, decimal balance)
    {
        AccountId = accountId;
        Cuil = cuil;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public void ShowData()
    {
        Console.WriteLine("Datos de la Cuenta:");
        Console.WriteLine($"\tCuil: {Cuil}");
        Console.WriteLine($"\tFirst Name: {FirstName}");
        Console.WriteLine($"\tLast Name: {LastName}");
        Console.WriteLine($"\tBalance: {Balance}");
    }

    public decimal Extract(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El valor debe ser mayor a $0.");
        }

        if (amount > Balance)
        {
            throw new ArgumentException("Saldo insuficiente.");
        }

        Balance -= amount;
        return Balance;
    }

    public decimal Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El valor debe ser mayor a $0.");
        }

        Balance += amount;
        return Balance;
    }

    public static bool ValidateCuil(string cuil)
    {
        if (cuil.Length != 11)
        {
            return false;
        }

        var genre = int.Parse(cuil[..2]);
        var possibleGenres = new[] { 20, 23, 27, 30 };

        if (!possibleGenres.Contains(genre))
        {
            return false;
        }

        var validatorsFactors = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        var validatorDigit = int.Parse(cuil.Substring(cuil.Length - 1, 1));
        var result = validatorsFactors.Select((t, i) => t * int.Parse(cuil[i].ToString())).Sum() % 11;

        return result switch
        {
            0 when validatorDigit == 0 => true,
            1 when validatorDigit == 9 && genre == 23 => true,
            1 when validatorDigit == 4 && genre == 23 => true,
            _ => validatorDigit == 11 - result
        };
    }
}