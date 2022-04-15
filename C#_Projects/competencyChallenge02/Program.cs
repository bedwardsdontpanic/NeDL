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

        Console.WriteLine("There are currently " + validCount + " restaurant(s) in the class... ");

        if(validCount >= 10) {
            Console.WriteLine("restaurant class size is already at its max of " + validCount + ". Returning... \n");
            return theRestaurants;
        }

        Console.Write("Enter the name of the new restaurant: ");
        string newrestaurant = Console.ReadLine();
        bool created = false;

        for(int i = 0; i < 10; i++) {
            if((theRestaurants[i] == "" || theRestaurants[i] == null) && created == false) {
                theRestaurants[i] = newrestaurant;
                created = true;
            }

        }

        return theRestaurants;

    }

    static string[] readrestaurants(string[] theRestaurants) {
        foreach(string restaurant in theRestaurants){
            if(restaurant != "" && restaurant != null){
                Console.WriteLine(restaurant);
            }
        }

        return theRestaurants;
    }

    static string[] updaterestaurants(string[] theRestaurants) {
        
        Console.Write("Enter the restaurant you'd like to replace: ");
        string restaurantToReplace = Console.ReadLine();
        
        Console.Write("Enter the restaurant you'd like to make in their place: ");
        string replacementrestaurant = Console.ReadLine();

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

            if(theRestaurants[i] == restaurantToDelete) {
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
            return false;
        }
    }

    static bool validateInt(string s) {

        if(int.TryParse(s, out int x) == true && x >= 0) {
            return true;
        }

        else {
            return false;
        }
    }

    static void runProgram(string[] theRestaurants) {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do{
            Console.Write("What would you like to do? Type the letter to choose \nL) Load into array \nC) Create restaurants \nR) Read all restaurants \nU) Update a restaurant \nD) Delete a restaurant \nS) Save array to file \nQ) Quit the program \n");
            input = Console.ReadLine();
            input = input.ToUpper();
            charCheck = validateSelection(input);
           
           if(charCheck == false){
               Console.WriteLine("Invalid input. Try again...\n");
               continue;
            }

            selection = Convert.ToChar(input);

            switch(selection){
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
