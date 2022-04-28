//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public abstract class BankAccount {

    public int accountId{
        get; set;
    }
    public string accountType{
        get; set;
    }
    public double currentBalance{
        get; set;
    }

    public BankAccount() {
        this.accountId = 0;
        this.accountType = "";
        this.currentBalance = 0;
    }

    public BankAccount(int accountId, string accountType, double currentBalance) {
        this.accountId = accountId;
        this.accountType = accountType;
        this.currentBalance = currentBalance;
    }

    public abstract string toFileFormat();

    public void deposit(double amount) {
        if(amount > 0){
            Console.WriteLine("Old balance: " + currentBalance);
            currentBalance += amount;
            Console.WriteLine("New balance after depositing " + amount + ": " + currentBalance + "\n");
        }    
        else{
            Console.WriteLine("\nYou cannot deposit a negative or zero amount. \n");
        }
    }

    public abstract bool withdraw(double amount);

    public override string ToString() {
        return "Account ID: " + accountId + ", AccountType: " + accountType + ", Current Balance: " + currentBalance;
    }

}