using System;
using BankingSystem;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            var trump = new StoreAccount("Donald Trump");
            //var success = trump.Deposit(45);


            var dimitris = new Account("dimitris");
            dimitris.Deposit(500);


            var result = dimitris.Withdraw(100);
            if (result == true)
            {
                Console.WriteLine($"take your money!, Your new balance is {dimitris.Balance}");
            }
            else
            {
                Console.WriteLine("no money");
            }

        }
        public static void Withdraw(decimal amount, Account account)
        {
            var result = account.Withdraw(amount);
            HandleTransactionResult(account, result);

        }
        //public static void Deposit(decimal amount, Account account)
        //{
        //    var success = account.Deposit(amount);
        //    HandleTransactionResult(account, success);

        //}
        public static void HandleTransactionResult(Account account, bool transactionResult)
        {
            if (transactionResult)
            {
                Console.WriteLine($"Available balance:{account.Balance}, Total transactions: {account.NumberOfTransactions}");
            }
            else
            {
                Console.WriteLine("transaction could not completed");
            }
        }
    }

}
public class Account
{
    public string CustomerName { get; private set; }
    public decimal Balance { get; private set; }
    public int NumberOfTransactions { get; private set; }

    public Account(string customerName)
    {
        CustomerName = customerName;
    }
    public bool Deposit(decimal amount)
    {
        if (amount >= 5000 || amount < 1)
        {
            return false;
        }
        NumberOfTransactions++;
        Balance += amount;
        return true;
    }
    public bool Withdraw(decimal amount)
    {
        if (amount > 5000 ||
            amount > Balance ||
            amount < 1)
        {
            return false;
        }
        NumberOfTransactions++;
        Balance -= amount;
        return true;

    }


}

public class StoreAccount : Account
{
    public string StoreName { get; set; }
    public AccountCategoryId AccountCategory { get; set; }

    public StoreAccount(string customerName) : base(customerName)
    {
        AccountCategory = AccountCategoryId.Senior;

    }
    public bool ChangeCategory(AccountCategoryId AccountCategory)
    {

        if (Balance <= 1000 && AccountCategory == AccountCategoryId.Basic)

        {

            return true;

        }
        else if (Balance <= 5000 && AccountCategory == AccountCategoryId.Mid)

        {

            return true;

        }
        else if (Balance <= 10000 && AccountCategory == AccountCategoryId.Senior)

        {

            return true;

        }
        else if (Balance > 10000 && AccountCategory == AccountCategoryId.Lead)

        {

            return true;

        }

        else

        {

            return false;

        }

    }
}



