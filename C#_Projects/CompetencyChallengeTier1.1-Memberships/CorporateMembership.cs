public class CorporateMembership: Membership {
    public CorporateMembership() {
        this.membershipId = "";
        this.membershipType = "";
        this.currentCharges = 0;
        this.annualCost = 0;
    }

    public CorporateMembership(string membershipId, string membershipType, double currentCharges, double annualCost)
    : base(membershipId, membershipType, currentCharges, annualCost)  {
        this.membershipId = membershipId;
        this.membershipType = membershipType;
        this.currentCharges = currentCharges;
        this.annualCost = annualCost;
    }

    public override bool applyCashBack(double amount){
        double total = amount * 0.07;
        Console.WriteLine("Current charges for the corporate membership to use for the 7% cashback: $" + currentCharges);
        Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of " + total + " has been made. ");
        currentCharges = 0;
        Console.WriteLine("Current charges after cashback: " + currentCharges + "\n");
        return true;
    }

    public override string ToString() {
        return "Membership ID: " + membershipId + ", Membership Type: " + membershipType + ", Current Monthly Charges: $" + currentCharges + 
        ", Annual Cost: $" + annualCost;
    }

    public override string toFileFormat() {
        return membershipId + "|" + membershipType + "|" + currentCharges + "|" + annualCost;
    }

}