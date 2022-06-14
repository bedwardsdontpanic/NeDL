//Employee (last name, first name, employee type; constructors, calculate bonus, toString)
using competencyChallenege03;
using System;

namespace competencyChallenege03 { 
public class Savings: BankAccount, IAnnualAmount {

    double annualInterestRate{get; set;}

    public Savings() {
        this.accountId = 0;
        this.accountType = "";
        this.currentBalance = 0;
        this.annualInterestRate = 0;
    }

    public Savings(int accountId, string accountType, double currentBalance, double annualInterestRate)
    : base(accountId, accountType, currentBalance)  {
        this.accountId = accountId;
        this.accountType = accountType;
        this.currentBalance = currentBalance;
        this.annualInterestRate = annualInterestRate;
    }


    public override bool withdraw(double amount) {
        if(currentBalance - amount < 0){
            Console.WriteLine("You cannot withdraw more than you have in your savings balance... \n");
            return false;
        }
        else{
            Console.WriteLine("Old Balance: " + currentBalance);
            currentBalance -= amount;
            Console.WriteLine("New Balance after withdrawing " + amount +":  " + currentBalance);
            return true;
        }

    }

    public double annualAmountEarned(){
        return currentBalance * annualInterestRate;
    }

    public override string ToString() {
        return "Account ID: " + accountId + ", Account Type: " + accountType + ", Current Balance: " + currentBalance + 
        ", Annual Interest Rate: " + annualInterestRate + ", Annual Amount Earned: " + annualAmountEarned().ToString("#.##");
    }

    public override string toFileFormat() {
        return accountId + "|" + accountType + "|" + currentBalance + "|" + annualInterestRate;
    }

}
}