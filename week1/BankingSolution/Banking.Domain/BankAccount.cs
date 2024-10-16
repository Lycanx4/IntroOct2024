


namespace Banking.Domain;

public class BankAccount
{
    decimal _balance = 5000;
    public void Deposit(decimal ammountToDeposit)
    {
        _balance += ammountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal ammountToWithdraw)
    {
        if (ammountToWithdraw <= _balance)
        {
            _balance -= ammountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }
    }
}

public class AccountOverdraftException : ArgumentOutOfRangeException;