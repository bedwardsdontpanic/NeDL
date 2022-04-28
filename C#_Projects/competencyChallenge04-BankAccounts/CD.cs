
public class CD: BankAccount, IAnnualAmount {

    public double annualInterestRate{get; set;}
    public double penalty{get; set;}

    public CD() {
        this.accountId = 0;
        this.accountType = "";
        this.currentBalance = 0;
        this.annualInterestRate = 0;
        this.penalty = 0;
    }

    public CD(int accountId, string accountType, double currentBalance, double annualInterestRate, double penalty)
    : base(accountId, accountType, currentBalance)  {
        this.accountId = accountId;
        this.accountType = accountType;
        this.currentBalance = currentBalance;
        this.annualInterestRate = annualInterestRate;
        this.penalty = penalty;
    }


    public override bool withdraw(double amount){
        if(currentBalance - (amount + (amount * penalty)) < 0){
            Console.WriteLine("You cannot withdraw more than your balance + penalty in your CD account... \n");
            return false;
        }
        else {
            Console.WriteLine("Old balance: " + currentBalance);
            currentBalance = currentBalance - amount - (amount * penalty);
            Console.WriteLine("Amount after withdraw of " + amount + " and penalty of " + (amount * penalty) + ": " + currentBalance + "\n");
            return true;
        }
    }

    public double annualAmountEarned(){
        return currentBalance * annualInterestRate;
    }

    public override string ToString() {
        return "Account ID: " + accountId + ", Account Type: " + accountType + ", Current Balance: " + currentBalance + 
        ", Annual Interest Rate: " + annualInterestRate + ", Penalty: " + penalty + ", Annual Amount Earned: " + annualAmountEarned().ToString("#.##");
    }

    public override string toFileFormat() {
        return accountId + "|" + accountType + "|" + currentBalance + "|" + annualInterestRate + "|" + penalty;
    }


}