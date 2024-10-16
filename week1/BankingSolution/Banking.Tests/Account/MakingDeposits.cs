
using Banking.Domain;

namespace Banking.Tests.Account;
public class MakingDeposits
{
    [Theory]
    [InlineData(112.25)]
    [InlineData(22.22)]
    public void MakingDepositIncreasesOurBalance(decimal amountToDeposit)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Deposit(amountToDeposit);

        var endingBalance = account.GetBalance();
        Assert.Equal(openingBalance + amountToDeposit, endingBalance);

    }
}
