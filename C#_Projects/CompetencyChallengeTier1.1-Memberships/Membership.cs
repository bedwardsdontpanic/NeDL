//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public abstract class Membership {

    public string membershipId{
        get; set;
    }
    public string membershipType{
        get; set;
    }
    public double currentCharges{
        get; set;
    }

    public double annualCost{
        get; set;
    }

    public Membership() {
        this.membershipId = "";
        this.membershipType = "";
        this.currentCharges = 0;
        this.annualCost = 0;
    }

    public Membership(string membershipId, string membershipType, double currentCharges, double annualCost) {
        this.membershipId = membershipId;
        this.membershipType = membershipType;
        this.currentCharges = currentCharges;
        this.annualCost = annualCost;
    }

    public abstract string toFileFormat();

    public bool purchase(double amount) {
        if(amount > 0){
            Console.WriteLine("Current charges before purchase: " + currentCharges);
            currentCharges += amount;
            Console.WriteLine("Current charges after purchase: " + currentCharges + "\n");
            return true;
        }
        else{
            Console.WriteLine("The amount needs to be greater than zero... " + "\n");
            return false;
        }
    }

    public bool returnPurchase(double amount) {
        if(amount > 0 && currentCharges - amount >= 0) {
            Console.WriteLine("Current charges before return.. : " + currentCharges);
            currentCharges -= amount;
            Console.WriteLine("Current charges after return... : " + currentCharges + "\n");
            return true;
        }    
        else{
            Console.WriteLine("Invalid entry... " + "\n");
            return false;
        }
    }

    public abstract bool applyCashBack(double amount);    

    public override string ToString() {
        return "Membership ID: " + membershipId + ", membershipType: $" + membershipType + ", Current Balance: $" + currentCharges;
    }

}