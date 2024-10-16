
using Banking.Domain;

namespace Banking.Tests.Account;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // Arrange
        var account = new BankAccount();

        // Act
        decimal balance = account.GetBalance();

        // Assert
        Assert.Equal(5000M, balance);
    }
}
