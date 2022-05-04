public class ExecutiveMembership: Membership, ISpecialOffer {
    public ExecutiveMembership() {
        this.membershipId = "";
        this.membershipType = "";
        this.currentCharges = 0;
        this.annualCost = 0;
    }

    public ExecutiveMembership(string membershipId, string membershipType, double currentCharges, double annualCost)
    : base(membershipId, membershipType, currentCharges, annualCost)  {
        this.membershipId = membershipId;
        this.membershipType = membershipType;
        this.currentCharges = currentCharges;
        this.annualCost = annualCost;
    }


    public override bool applyCashBack(double amount){
        double total = 0;
        if(amount > 1000){
            Console.WriteLine("Current charges before using 8% cashback on an executtive membership on a purchase over $1000: $" + currentCharges);
            total = amount * 0.08;
            Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
            currentCharges = 0;
            Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
            return true;
        }
        else {
            Console.WriteLine("Current charges before using 6% cashback on an executtive membership on a purchase under $1000: $" + currentCharges);
            total = amount * 0.06;
            Console.WriteLine("Cash-back reward request for membership " + membershipId + " in the amount of $" + total + " has been made. ");
            currentCharges = 0;
            Console.WriteLine("Current charges after cashback: $" + currentCharges + "\n");
            return true;
        }
    }

    public double specialOffer(){
        return 0.5 * annualCost;
    }

    public override string ToString() {
        return "Membership ID: " + membershipId + ", Membership Type: " + membershipType + ", Current Monthly Charges: $" + currentCharges + 
        ", Annual Cost: $" + annualCost + ", Special Offer: $" + specialOffer().ToString("#.##");
    }

    public override string toFileFormat() {
        return membershipId + "|" + membershipType + "|" + currentCharges + "|" + annualCost;
    }

}