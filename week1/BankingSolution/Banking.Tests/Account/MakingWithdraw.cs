using Banking.Domain;

namespace Banking.Tests.Account;

public class MakingWithdraw
{
    [Fact]
    public void MakingWithdrawDecreasesOurBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var ammountToWithdraw = 112.25M;

        account.Withdraw(ammountToWithdraw);

        var endingBalance = account.GetBalance();
        Assert.Equal(openingBalance - ammountToWithdraw, endingBalance);

    }
}
