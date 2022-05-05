public class RegularMembership: Membership, ISpecialOffer {
    public RegularMembership() {
        this.membershipId = "";
        this.membershipType = "";
        this.currentCharges = 0;
        this.annualCost = 0;

    }

    public RegularMembership(string membershipId, string membershipType, double currentCharges, double annualCost)
    : base(membershipId, membershipType, currentCharges, annualCost)  {
        this.membershipId = membershipId;
        this.membershipType = membershipType;
        this.currentCharges = currentCharges;
        this.annualCost = annualCost;
    }

    public override bool applyCashBack(double amount){
        double total = amount * 0.05;
        Console.WriteLine("Current charges for regular membership before 5% cashback: $" + currentCharges);
        currentCharges = 0;
        Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
        Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
        return true;
    }

    public double specialOffer(){
        return 0.25 * annualCost;
    }

    public override string ToString() {
        return "Membership ID: " + membershipId + ", Membership Type: " + membershipType + ", Current Monthly Charges: $" + currentCharges + 
        ", Annual Cost: $" + annualCost + ", Special Offer: $" + specialOffer().ToString("#.##");
    }

    public override string toFileFormat() {
        return membershipId + "|" + membershipType + "|" + currentCharges + "|" + annualCost;
    }

}