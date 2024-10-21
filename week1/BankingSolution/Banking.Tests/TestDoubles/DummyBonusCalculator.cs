using Banking.Domain;

namespace Banking.Tests.TestDoubles;

public class DummyBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateBonusForDepositOn(decimal balance, decimal amount)
    {
        return 0;
    }
}
