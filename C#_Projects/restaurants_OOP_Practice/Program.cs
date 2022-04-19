#pragma warning disable 8604, 8600, 8601, 8602

class helloworld {
    public static void Main() {
        
        Restaurant[] theRestaurants = new Restaurant[25];
        runProgram(theRestaurants);
    }

    static Restaurant[] readFileIntoArray(){
        
        string[] theText = File.ReadLines(@"Restaurants.txt").ToArray();
        Restaurant[] theRestaurants = new Restaurant[25];

        for(int i = 0; i < theText.Count(); i++) {
            if(theText[i] != "" && theText[i] != null){
                string[] splitit = theText[i].Split('|');
                Restaurant newRest = new Restaurant(splitit[0], Convert.ToInt16(splitit[1]));
                theRestaurants[i] = newRest;
            }
        }


        Array.Resize(ref theRestaurants, 25);
        return theRestaurants;
    } 

    static Restaurant[] saveArrayIntoFile(Restaurant[] theRestaurants){
        
        using(StreamWriter SW = new StreamWriter("restaurants.txt")) {
        
        foreach(Restaurant rest in theRestaurants) {
            if(rest != null){
                SW.WriteLine(rest.Name + "|" + rest.Rating);
            }
        }

       return theRestaurants;
        }
    }

    static void createFile() {
        string fileName = @"Restaurant.txt";
        
        try {
            // Create the file.
            using (FileStream fst = File.Create(fileName)) {

            }
        }
        
        catch (Exception exc) {
            Console.WriteLine(exc.ToString());
        }
    }

    static Restaurant[] createRestaurant(Restaurant[] theRestaurants) {

        // Check if the count is over the max. 
        int validCount = 0;
        foreach(Restaurant restaurant in theRestaurants){
            if(restaurant != null){
                validCount++;
            }
        }

        Console.WriteLine("There are currently " + validCount + " restaurant(s)... ");

        if(validCount >= 25) {
            Console.WriteLine("Restaurant size is already at its max of " + validCount + ". Returning... \n");
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
//        string newRestaurant = newRestaurantName + "|" + theRating;

        Restaurant newRest = new Restaurant(newRestaurantName, Convert.ToInt16(theRating));

        for(int i = 0; i < 25; i++) {
            if(theRestaurants[i] == null) {
                theRestaurants[i] = newRest;
                break;
            }
        }

        Console.WriteLine(newRestaurantName + " has been created...\n");

        return theRestaurants;

    }

    static Restaurant[] readRestaurants(Restaurant[] theRestaurants) {
        foreach(Restaurant restaurant in theRestaurants){
            if(restaurant != null){
                Console.WriteLine("name: " + restaurant.Name + ", rating " + restaurant.Rating);
            }
        }
        
        Console.WriteLine("Returning to main menu...\n");
        return theRestaurants;
    }

    static Restaurant[] updateRestaurant(Restaurant[] theRestaurants) {
        
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



        int replacements = 0;
        for(int i = 0; i < theRestaurants.Length; i++) {
            if(theRestaurants[i] != null && theRestaurants[i].Name == restaurantToReplace) {
                theRestaurants[i] = new Restaurant(newRestaurantName, Convert.ToInt16(newRating));;
                replacements++;
            }
        }

        Console.WriteLine("There were " + replacements + " replacement(s) made... Returning to main menu...\n");
        return theRestaurants;
    }

    static Restaurant[] deleteRestaurant(Restaurant[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to delete: ");
        string restaurantToDelete = Console.ReadLine();
        int deletions = 0;

        for(int i = 0; i< theRestaurants.Count(); i++){
            if(theRestaurants[i] != null && theRestaurants[i].Name == restaurantToDelete){
                theRestaurants[i] = null;
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

    static void runProgram(Restaurant[] theRestaurants) {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do {
            Console.Write("What would you like to do? Type the letter to choose \nL) Load into array \nC) Create Restaurant \nR) Read all Restaurant \nU) Update a restaurant \nD) Delete a restaurant \nS) Save array to file \nQ) Quit the program \n");
            input = Console.ReadLine();
            input = input.ToUpper();
            charCheck = validateSelection(input);
           
           if(charCheck == false){
               continue;
            }

            selection = Convert.ToChar(input);

            switch(selection) {
                case 'L':
                    Console.WriteLine("Loading Restaurant from array...\n");
                    theRestaurants = readFileIntoArray();
                    continue;

                case 'S':
                    Console.WriteLine("Saving Restaurant from array to file...\n");
                    theRestaurants = saveArrayIntoFile(theRestaurants);
                    continue;

                case 'C':
                    Console.WriteLine("Creating Restaurant...\n");                
                    theRestaurants = createRestaurant(theRestaurants);
                    continue;

                case 'R':
                    Console.WriteLine("Reading Restaurant...");                
                    theRestaurants = readRestaurants(theRestaurants);
                    continue;

                case 'U':
                    Console.WriteLine("Updating Restaurant...\n");
                    theRestaurants = updateRestaurant(theRestaurants);
                    break;

                case 'D':
                    Console.WriteLine("Deleting Restaurant...\n");
                    theRestaurants = deleteRestaurant(theRestaurants);
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


public class Restaurant {
    private string name;
    private int rating;


    public Restaurant(string name, int rating) {
        this.name = name;
        this.rating = rating;
    }

    public string Name {
        get { return name;  }
        set { name = value; }
    }

    public int Rating {
        get { return rating;  }
        set { rating = value; }
    }
}