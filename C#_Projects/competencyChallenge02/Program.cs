#pragma warning disable 8604, 8600, 8601, 8602

class helloworld {
    public static void Main() {
        
        string[] theRestaurants = new string[25];
        runProgram(theRestaurants);
    }

    static string[] readFileIntoArray(){
        
        string[] theRestaurants = File.ReadLines(@"restaurants.txt").ToArray();
        Array.Resize(ref theRestaurants, 25);
        return theRestaurants;
    } 

    static string[] saveArrayIntoFile(string[] theRestaurants){
        
        System.IO.File.WriteAllLines(@"restaurants.txt", theRestaurants);
        return theRestaurants;
    }

    static void createFile() {
        string fileName = @"restaurants.txt";
        
        try {
            // Create the file.
            using (FileStream fst = File.Create(fileName)) {

            }
        }
        
        catch (Exception exc) {
            Console.WriteLine(exc.ToString());
        }
    }

    static string[] createRestaurants(string[] theRestaurants) {

        // Check if the count is over the max. 
        int validCount = 0;
        foreach(string restaurant in theRestaurants){
            if(restaurant != ""  && restaurant != null){
                validCount++;
            }
        }

        Console.WriteLine("There are currently " + validCount + " restaurant(s)... ");

        if(validCount >= 25) {
            Console.WriteLine("restaurants size is already at its max of " + validCount + ". Returning... \n");
            return theRestaurants;
        }

        // Get name of new restaurant and validate
        string newRestaurantName;
        do{
            Console.Write("Enter the name of the new restaurant: ");
            newRestaurantName = Console.ReadLine();
        }
        while(validateName(newRestaurantName) == false);

        // Get rating of new restaurant and validate
        string theRating;
        do {
            Console.Write("Enter the review score for " + newRestaurantName +"(use a score of 1-5 please): ");
            theRating = Console.ReadLine();
        }
        while(validateInt(theRating)==false);
        
        // Concatenate name + score and insert into first available space. 
        string newRestaurant = newRestaurantName + "|" + theRating;

        for(int i = 0; i < 25; i++) {
            if(theRestaurants[i] == "" || theRestaurants[i] == null) {
                theRestaurants[i] = newRestaurant;
                break;
            }
        }

        Console.WriteLine(newRestaurantName + " has been created...\n");

        return theRestaurants;

    }

    static string[] readrestaurants(string[] theRestaurants) {
        foreach(string restaurant in theRestaurants){
            if(restaurant != "" && restaurant != null){
                string[] subs = restaurant.Split('|');
                Console.WriteLine("name: " + subs[0] + ", rating " + subs[1]);
            }
        }
        
        Console.WriteLine("Returning to main menu...\n");
        return theRestaurants;
    }

    static string[] updateRestaurants(string[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to replace: ");
        string restaurantToReplace = Console.ReadLine();
        
        
        string newRestaurantName;
        do{
            Console.Write("Enter the name of the new restaurant to replace " + restaurantToReplace + ": ");
            newRestaurantName = Console.ReadLine();
        }
        while(validateName(newRestaurantName) == false);

        
        string newRating;
        do {
            Console.Write("Enter the review score for " + newRestaurantName +"(use a score of 1-5 please): ");
            newRating = Console.ReadLine();
        }
        while(validateInt(newRating)==false);

        
        string replacementrestaurant = newRestaurantName + "|" + newRating;


        int replacements = 0;
        for(int i = 0; i < theRestaurants.Length; i++) {
            
            if(theRestaurants[i] == null || theRestaurants[i] == "") {
                continue;
            }

            string[] subs = theRestaurants[i].Split('|');
            if(restaurantToReplace == subs[0]) {
                theRestaurants[i] = replacementrestaurant;
                replacements++;
            }
        }

        Console.WriteLine("There were " + replacements + " replacement(s) made... Returning to main menu...\n");
        return theRestaurants;
    }

    static string[] deleteRestaurants(string[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to delete: ");
        string restaurantToDelete = Console.ReadLine();
        int deletions = 0;

        for(int i = 0; i < theRestaurants.Length; i++) {
            
            if(theRestaurants[i] == null || theRestaurants[i] == "") {
                continue;
            }

            string[] subs = theRestaurants[i].Split('|');
            if(restaurantToDelete == subs[0]) {
                theRestaurants[i] = "";
                deletions++;
            }

        }

        Console.WriteLine("There were " + deletions + " deletion(s)... Returning to main menu...\n");
        return theRestaurants;

    }

    static bool validateSelection(string s) {

        if(Char.TryParse(s, out char x) == true && (x == 'L' || x == 'S' || x == 'C' || x == 'R' || x == 'U' || x == 'D' || x == 'Q')) {
            return true;
        }

        else {
            Console.WriteLine("Invalid selection. Try again. ");
            return false;
        }
    }

    static bool validateInt(string s) {

        if(int.TryParse(s, out int x) == true && x >= 1 && x <= 5) {
            return true;
        }

        else {
            Console.WriteLine("Invalid input. Try again... ");
            return false;
        }
    }

    static bool validateName(string s) {

        if((s.Contains('|')) == true) {
            Console.WriteLine("Why would you put a pipe in your restaurant's name? Don't do that. ");
            return false;
        }

        else if(s =="" || s == null){
            Console.WriteLine("Please be sure to enter a value.. ");
            return false;
        }

        else {
            return true;
        }
    }

    static void runProgram(string[] theRestaurants) {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do {
            Console.Write("What would you like to do? Type the letter to choose \nL) Load into array \nC) Create restaurants \nR) Read all restaurants \nU) Update a restaurant \nD) Delete a restaurant \nS) Save array to file \nQ) Quit the program \n");
            input = Console.ReadLine();
            input = input.ToUpper();
            charCheck = validateSelection(input);
           
           if(charCheck == false){
               continue;
            }

            selection = Convert.ToChar(input);

            switch(selection) {
                case 'L':
                    Console.WriteLine("Loading restaurants from array...\n");
                    theRestaurants = readFileIntoArray();
                    continue;

                case 'S':
                    Console.WriteLine("Saving restaurants from array to file...\n");
                    theRestaurants = saveArrayIntoFile(theRestaurants);
                    continue;

                case 'C':
                    Console.WriteLine("Creating restaurants...\n");                
                    theRestaurants = createRestaurants(theRestaurants);
                    continue;

                case 'R':
                    Console.WriteLine("Reading restaurants...");                
                    theRestaurants = readrestaurants(theRestaurants);
                    continue;

                case 'U':
                    Console.WriteLine("Updating restaurants...\n");
                    theRestaurants = updateRestaurants(theRestaurants);
                    break;

                case 'D':
                    Console.WriteLine("Deleting restaurants...\n");
                    theRestaurants = deleteRestaurants(theRestaurants);
                    break;

                case 'Q':
                    Console.WriteLine("Exiting program...\n");
                    break;

                default:
                    Console.WriteLine("\n\nInvalid input... Re-enter please.");
                    continue;
            }

        }

        while(selection !='Q');
    }
    

}
