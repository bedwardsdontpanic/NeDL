#pragma warning disable 8604, 8600, 8601, 8602, 8603

class helloworld {
    public static void Main() {

        runProgram();

    }

    static List<Membership> loadFileIntoList() {
        
        string[] theText = File.ReadLines("Memberships.txt").ToArray();
        List<Membership> theMemberships = new List<Membership>();
        for(int i = 0; i < theText.Count(); i++) {
            if(theText[i] != "" && theText[i] != null) {
                string[] splitit = theText[i].Split('|');
                if(splitit[1] == "Corporate") {
                    CorporateMembership newMembership = new CorporateMembership(splitit[0], splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                    theMemberships.Add(newMembership);
                }
                else if(splitit[1] == "Executive") {
                    ExecutiveMembership newMembership = new ExecutiveMembership(splitit[0], splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                    theMemberships.Add(newMembership);
                }
                else if(splitit[1] == "Nonprofit") {
                    NonProfitMembership newMembership = new NonProfitMembership(splitit[0], splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                    theMemberships.Add(newMembership);
                }
                else if(splitit[1] == "Regular") {
                    RegularMembership newMembership = new RegularMembership(splitit[0], splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                    theMemberships.Add(newMembership);
                }
            }
        }

        return theMemberships;
    } 

    static void saveMembershipIntoFile(Membership theMembership) {
        List<Membership> theMemberships = new List<Membership>();
        theMemberships = loadFileIntoList();

        if(GetMembership(theMembership.membershipId) == null) {
            theMemberships.Add(theMembership);
            Console.WriteLine("adding new membership to file... \n");
        }

        using(StreamWriter SW = new StreamWriter("Memberships.txt")) {
            foreach(Membership currentMembership in theMemberships) {
                if(currentMembership.membershipId != theMembership.membershipId){
                    SW.WriteLine(currentMembership.toFileFormat());
                }
                else{
                    SW.WriteLine(theMembership.toFileFormat());
                }
            }
        }
    }

    static void readMemberships() {
        
        List<Membership> theMemberships = new List<Membership>();
        theMemberships = loadFileIntoList();

        foreach(Membership theMembership in theMemberships) {
            Console.WriteLine(theMembership);
        }

        Console.WriteLine("\nReturning to main menu...\n");
    }

    static void purchaseMenu() {
        string theId = "";
        do {
            Console.Write("Enter the membership number: ");
            theId = Console.ReadLine();
        }
        while(validateInt(theId) == false || GetMembership(theId) == null);

        Membership theMembership = GetMembership(theId);
        string purchaseAmountEntry = "";
        Console.WriteLine("Membership info: " + theMembership);
        do {
            Console.Write("Enter the amount the purchase costs: ");
            purchaseAmountEntry = Console.ReadLine();
        }
        while(validateDouble(purchaseAmountEntry) == false);

        double withdrawAmount = Convert.ToDouble(purchaseAmountEntry);
        theMembership.purchase(withdrawAmount);
        saveMembershipIntoFile(theMembership);
    }

    static void cashbackMenu() {
        string theId = "";
        do {
            Console.Write("Enter the membership number: ");
            theId = Console.ReadLine();
        }
        while(validateInt(theId) == false || GetMembership(theId) == null);

        Membership theMembership = GetMembership(theId);

        if(theMembership.membershipType != "Nonprofit") {
            theMembership.applyCashBack(theMembership.currentCharges);
        }
        
        else {

            string userInput = "";
            do {
            Console.WriteLine("Were the charges for the nonprofit membership military or education purchases? (y/n): ");
            userInput = Console.ReadLine();
            }
            while(validateYesNo(userInput.ToUpper()) == false);
            
            if(userInput.ToUpper().ToCharArray()[0] == 'Y') {
                NonProfitMembership theNPMem = (NonProfitMembership)theMembership;
                theNPMem.applyCashBack(theMembership.currentCharges, true);
                saveMembershipIntoFile(theNPMem);
            }

            else{
                theMembership.applyCashBack(theMembership.currentCharges);
                saveMembershipIntoFile(theMembership);
            }
        }
    }

    static void returnMenu() {
        string theId = "";
        do {
            Console.Write("Enter the membership number: ");
            theId = Console.ReadLine();
        }
        while(validateInt(theId) == false || GetMembership(theId) == null);

        Membership theMembership = GetMembership(theId);
        string returnAmountEntry = "";

        Console.WriteLine("Membership info: " + theMembership);

        do {
            Console.Write("Your balance for the " + theMembership.membershipType + " membership is $" + theMembership.currentCharges + ". Enter an amount to return: ");
            returnAmountEntry = Console.ReadLine();
        }
        while(validateDouble(returnAmountEntry) == false || theMembership.returnPurchase(Convert.ToDouble(returnAmountEntry)) == false);
        Console.WriteLine(theMembership.currentCharges);
        double returnAmount = Convert.ToDouble(returnAmountEntry);
        theMembership.returnPurchase(returnAmount);
        Console.WriteLine(theMembership.currentCharges);
        saveMembershipIntoFile(theMembership);
    }

    static void createMembership() {
        string membershipType = "";
        do {
            Console.WriteLine("What type of membership would you like to create? Type the letter in to select. \nC: Corporate \nE: Executive \nN: Nonprofit \nR: Regular");
            membershipType = Console.ReadLine();
        }
        while(validateMembershipType(membershipType) == "");
        
        string newMembershipType = validateMembershipType(membershipType);
        
        switch(newMembershipType) {
            case "Corporate":
                CorporateMembership newCorpMembership = new CorporateMembership(getNextMembershipID(), "Corporate", 0, 200);
                saveMembershipIntoFile(newCorpMembership);
                Console.WriteLine("A new corporate membership has been created: \n" + newCorpMembership + "\n");
                break;
            case "Executive":
                ExecutiveMembership newExecMembership = new ExecutiveMembership(getNextMembershipID(), "Executive", 0, 300);
                saveMembershipIntoFile(newExecMembership);
                Console.WriteLine("A new executive membership has been created: \n" + newExecMembership + "\n");
                break;
            case "Nonprofit":
                NonProfitMembership newNPMembership = new NonProfitMembership(getNextMembershipID(), "Nonprofit", 0, 250);
                saveMembershipIntoFile(newNPMembership);
                Console.WriteLine("A new nonprofit membership has been created: \n" + newNPMembership + "\n");
                break;
            case "Regular":
                RegularMembership newRegMembership = new RegularMembership(getNextMembershipID(), "Regular", 0, 100);
                saveMembershipIntoFile(newRegMembership);
                Console.WriteLine("A new regular membership has been created: \n" + newRegMembership + "\n");
                break;
        }
    }

    static void updateMembership() {
        string theId = "";
        do {
            Console.Write("Enter the membership number: ");
            theId = Console.ReadLine();
        }
        while(validateInt(theId) == false || GetMembership(theId) == null);

        Membership theMembership = GetMembership(theId);
        Console.WriteLine("Membership details: \n" + theMembership);   

        string input = "";
        do{
            Console.WriteLine("Enter a new monthly total for the account: ");
            input = Console.ReadLine();
        }
        while(validateDouble(input) == false);
        Console.WriteLine("Current charges before update: " + theMembership.currentCharges);
        theMembership.currentCharges = Convert.ToDouble(input);
        Console.WriteLine("Current charges after update: " + theMembership.currentCharges);
        saveMembershipIntoFile(theMembership);
    }

    static Membership GetMembership(string theId) {
        List<Membership> theMemberships = new List<Membership>();
        theMemberships = loadFileIntoList();

        foreach(Membership currentMembership in theMemberships) {
            if(currentMembership.membershipId == theId && currentMembership.membershipType == "Corporate") {
                return (CorporateMembership)currentMembership;
            }
            else if(currentMembership.membershipId == theId && currentMembership.membershipType == "Executive") {
                return (ExecutiveMembership)currentMembership;
            }
            else if(currentMembership.membershipId == theId && currentMembership.membershipType == "Nonprofit") {
                return (NonProfitMembership)currentMembership;
            }
            else if(currentMembership.membershipId == theId && currentMembership.membershipType == "Regular") {
                return (RegularMembership)currentMembership;
            }
        }

        return null;
    }

    static void deleteMembership() {
        string theId = "";
        do {
        Console.WriteLine("Enter the ID of the membership you'd like to delete: ");
            theId = Console.ReadLine();
        }
        while(validateInt(theId) == false || GetMembership(theId) == null);

        List<Membership> theMemberships = new List<Membership>();
        theMemberships = loadFileIntoList();

        theMemberships.RemoveAll(x => x.membershipId == theId);

        Console.WriteLine(theMemberships.Count());

        File.WriteAllText("Memberships.txt", String.Empty);

        using(StreamWriter SW = new StreamWriter("Memberships.txt")) {
            foreach(Membership currentMembership in theMemberships) {
                SW.WriteLine(currentMembership.toFileFormat());
            }
        }
    }

    static string getNextMembershipID() {
        List<Membership> theMemberships = new List<Membership>();
        theMemberships = loadFileIntoList();
        int max = theMemberships.Max(p => Convert.ToInt32(p.membershipId)) + 1;

        string theID = max.ToString();

        if(theID.Length == 1) {
            theID = "000" + theID;
        }
        else if(theID.Length == 2) {
            theID = "00" + theID;
        }
        else if(theID.Length == 3) {
            theID = "0" + theID;
        }

        return theID;
    }

    static string validateMembershipType(string s) {
        s = s.ToUpper();
        if(Char.TryParse(s, out char x) == false) {

            Console.WriteLine("Invalid input. Try again... \n");
            return "";
        }

        switch(x) {
            case 'C':
                return "Corporate";
            case 'E':
                return "Executive";
            case 'N':
                return "Nonprofit";
            case 'R':
                return "Regular";
        }

        Console.WriteLine(x + " is an invalid input. Try again... \n");
        return "";
        
    }
    static bool validateSelection(string s) {

        if(Char.TryParse(s, out char x) == true && (x == 'C' || x == 'R' || x == 'U' || x == 'D' || x == 'L' || x == 'P' || x == 'T' || x == 'A' || x == 'Q')) {
            return true;
        }

        else {
            Console.WriteLine("\nInvalid selection. Try again. ");
            return false;
        }
    }

    static bool validateYesNo(string s) {

        if(Char.TryParse(s, out char x) == true && (x == 'Y' || x == 'N')) {
            return true;
        }

        else {
            Console.WriteLine("\nInvalid selection. Try again. ");
            return false;
        }
    }

    static bool validateDouble(string s) {

        if(double.TryParse(s, out double x) == true && x >= 0) {
            return true;
        }

        else {
            Console.WriteLine("\nInvalid input. Try again... ");
            return false;
        }
    }

    static bool validateInt(string s) {

        if(Int32.TryParse(s, out int x) == true && x >= 0) {
            return true;
        }

        else {
            Console.WriteLine("\nInvalid input. Try again... ");
            return false;
        }
    }

    static void runProgram() {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do {
            Console.Write("What would you like to do? Type the letter to choose \nC) Create a membership \nR) Read memberships \nU) Update a membership's monthly charges \nD) Delete a membership " +
            "\nL) List all memberships \nP) Open purchase menu \nT) Open return menu  \nA) Open cashback menu \nQ) Quit the program \n");
            input = Console.ReadLine();
            input = input.ToUpper();
            charCheck = validateSelection(input);
           
        if(charCheck == false) {
            continue;
        }

        selection = Convert.ToChar(input);

        switch(selection) {

            case 'C':
                Console.WriteLine("Creating a membership...\n");
                createMembership();
                continue;
            case 'R':
                Console.WriteLine("Listing all Memberships...\n");  
                readMemberships();
                continue;
            case 'U':
                Console.WriteLine("Updating a membership...\n");
                updateMembership();
                continue;
            case 'D':
                Console.WriteLine("Deleting a membership...\n");      
                deleteMembership();          
                continue;
            case 'L':
                Console.WriteLine("Listing all memberships...\n");      
                readMemberships();          
                continue;
            case 'P':
                Console.WriteLine("Performing a purchase transcation...\n");
                purchaseMenu();
                continue;
            case 'T':
                Console.WriteLine("Performing a return transaction...\n");
                returnMenu();
                continue;
            case 'A':
                Console.WriteLine("Applying cashback rewards...\n");    
                cashbackMenu();           
                continue;
            case 'Q':
                Console.WriteLine("\nExiting program...\n");
                break;
            default:
                Console.WriteLine("\n\nInvalid input... Re-enter please.");
                continue;
            }
        }
        while(selection !='Q');
    }

}


