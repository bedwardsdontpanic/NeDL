//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class Checkings: BankAccount {

    public double annualFee {get; set;}

    public Checkings() {
        this.accountId = 0;
        this.accountType = "";
        this.currentBalance = 0;
        this.annualFee = 0;
    }

    public Checkings(int accountId, string accountType, double currentBalance, double annualFee)
        : base(accountId, accountType, currentBalance)  {
        this.accountId = accountId;
        this.accountType = accountType;
        this.currentBalance = currentBalance;
        this.annualFee = annualFee;
    }


    public override bool withdraw(double amount){
        if(currentBalance*0.5 - amount < 0){
            Console.WriteLine("You cannot withdraw more than 50% of your checkings account balance... \n");
            return false;
        }
        else{
            Console.WriteLine("Old Balance: " + currentBalance);
            currentBalance -= amount;
            Console.WriteLine("New Balance after withdrawing " + amount +":  " + currentBalance + "\n");
            return true;
        }
    }

    public override string ToString() {
        return "Account ID: " + accountId + ", Account Type: " + accountType + ", Current Balance: " + currentBalance + ", annual fee: " + annualFee;
    }

    public override string toFileFormat() {
        return accountId + "|" + accountType + "|" + currentBalance + "|" + annualFee;
    }


}