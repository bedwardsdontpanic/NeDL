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
                Console.WriteLine(" A file created with name mytest.txt\n\n");
            }
        }
        
        catch (Exception exc) {
            Console.WriteLine(exc.ToString());
        }
    }

    static string[] createrestaurants(string[] theRestaurants) {

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

        string newRestaurantName;
        do{
            Console.Write("Enter the name of the new restaurant: ");
            newRestaurantName = Console.ReadLine();
        }
        while(validateName(newRestaurantName) == false);
        
        string theRating;
        do {
            Console.Write("Enter the review score for " + newRestaurantName +"(use a score of 1-5 please): ");
            theRating = Console.ReadLine();
        }
        while(validateInt(theRating)==false);
        
        string newrestaurant = newRestaurantName + "|" + theRating;

        for(int i = 0; i < 25; i++) {
            if(theRestaurants[i] == "" || theRestaurants[i] == null) {
                theRestaurants[i] = newrestaurant;
                break;
            }
        }

        return theRestaurants;

    }

    static string[] readrestaurants(string[] theRestaurants) {
        foreach(string restaurant in theRestaurants){
            if(restaurant != "" && restaurant != null){
                string[] subs = restaurant.Split('|');
                Console.WriteLine("name: " + subs[0] + ", rating " + subs[1]);
            }
        }

        return theRestaurants;
    }

    static string[] updaterestaurants(string[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to replace: ");
        string restaurantToReplace = Console.ReadLine();
        
        Console.Write("Enter the restaurant you'd like to make in their place: ");
        string replacementrestaurantName = Console.ReadLine();

        Console.Write("Enter the score you'd like to give " + replacementrestaurantName + ". (1-5 please): ");
        string replacementrestaurantScore = Console.ReadLine();

        string replacementrestaurant = replacementrestaurantName + "|" + replacementrestaurantScore;

        for(int i = 0; i < theRestaurants.Length; i++) {
            theRestaurants[i] = theRestaurants[i].Replace(restaurantToReplace, replacementrestaurant);
        }

        return theRestaurants;
    }

    static string[] deleterestaurants(string[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to delete: ");
        string restaurantToDelete = Console.ReadLine();
        int deletions = 0;

        for(int i = 0; i < theRestaurants.Length; i++) {
            string[] subs = theRestaurants[i].Split('|');
            Console.Write(subs[0]);
            if(theRestaurants[i] == subs[0]) {
                theRestaurants[i] = theRestaurants[i].Replace(restaurantToDelete, "");
                deletions++;
            }

        }

        Console.WriteLine("There were " + deletions + " deletions... ");
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
                    theRestaurants = createrestaurants(theRestaurants);
                    continue;

                case 'R':
                    Console.WriteLine("Reading restaurants...\n");                
                    theRestaurants = readrestaurants(theRestaurants);
                    continue;

                case 'U':
                    Console.WriteLine("Updating restaurants...\n");
                    theRestaurants = updaterestaurants(theRestaurants);
                    break;

                case 'D':
                    Console.WriteLine("Deleting restaurants...\n");
                    theRestaurants = deleterestaurants(theRestaurants);
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
