public class NonProfitMembership: Membership {

    public NonProfitMembership() {
        this.membershipId = "";
        this.membershipType = "";
        this.currentCharges = 0;
        this.annualCost = 0;
    }

    public NonProfitMembership(string membershipId, string membershipType, double currentCharges, double annualCost)
    : base(membershipId, membershipType, currentCharges, annualCost)  {
        this.membershipId = membershipId;
        this.membershipType = membershipType;
        this.currentCharges = currentCharges;
        this.annualCost = annualCost;
    }

    public override bool applyCashBack(double amount){
        Console.WriteLine("Current charges before using 5% cashback on Nonprofit membership on a purchase of non-military/education: $" + currentCharges);
        double total = amount * 0.05;
        currentCharges = 0;
        Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
        Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
        return false;
    }

    public bool applyCashBack(double amount, bool isMilitaryOrEducation){
        if(isMilitaryOrEducation) {
            Console.WriteLine("Current charges before using 10% cashback on Nonprofit membership on a purchase of military/education: $" + currentCharges);
            double total = amount * 0.1;
            currentCharges = 0;
            Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
            Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
        }
        else {
            Console.WriteLine("Current charges before using 5% cashback on Nonprofit membership on a purchase of non-military/education: $" + currentCharges);
            double total = amount * 0.05;
            currentCharges = 0;
            Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
            Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
        }
        return false;
    }

    public override string ToString() {
        return "Membership ID: " + membershipId + ", Membership Type: " + membershipType + ", Current Monthly Charges: $" + currentCharges + 
        ", Annual Cost: $" + annualCost;
    }

    public override string toFileFormat() {
        return membershipId + "|" + membershipType + "|" + currentCharges + "|" + annualCost;
    }

}