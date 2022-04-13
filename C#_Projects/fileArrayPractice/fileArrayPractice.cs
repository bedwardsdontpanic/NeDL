#pragma warning disable 8604, 8600, 8601, 8602

class helloworld {
    public static void Main() {
        
        string[] theStudents = new string[10];
        runProgram(theStudents);
    }

    static string[] readFileIntoArray(){
        
        string[] theStudents = File.ReadLines(@"students.txt").ToArray();
        Array.Resize(ref theStudents, 10);
        return theStudents;
    } 

    static string[] saveArrayIntoFile(string[] theStudents){
        System.IO.File.WriteAllLines(@"students.txt", theStudents);
        return theStudents;
    }

    static void createFile() {
        string fileName = @"students.txt";
        
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

    static string[] createStudents(string[] theStudents) {

        int validCount = 0;
        foreach(string student in theStudents){
            if(student != ""  && student != null){
                validCount++;
            }
        }

        Console.WriteLine("There are currently " + validCount + " student(s) in the class... ");

        if(validCount >= 10) {
            Console.WriteLine("Student class size is already at its max of " + validCount + ". Returning... \n");
            return theStudents;
        }

        Console.Write("Enter the name of the new student: ");
        string newStudent = Console.ReadLine();
        bool created = false;

        for(int i = 0; i < 10; i++) {
            if((theStudents[i] == "" || theStudents[i] == null) && created == false) {
                theStudents[i] = newStudent;
                created = true;
            }

        }

        return theStudents;

    }

    static string[] readStudents(string[] theStudents) {
        foreach(string student in theStudents){
            if(student != "" && student != null){
                Console.WriteLine(student);
            }
        }

        return theStudents;
    }

    static string[] updateStudents(string[] theStudents) {
        
        Console.Write("Enter the student you'd like to replace: ");
        string studentToReplace = Console.ReadLine();
        
        Console.Write("Enter the student you'd like to make in their place: ");
        string replacementStudent = Console.ReadLine();

        for(int i = 0; i < theStudents.Length; i++) {
            theStudents[i] = theStudents[i].Replace(studentToReplace, replacementStudent);
        }

        return theStudents;
    }

    static string[] deleteStudents(string[] theStudents) {
        
        Console.Write("Enter the student you'd like to delete: ");
        string studentToDelete = Console.ReadLine();
        int deletions = 0;

        for(int i = 0; i < theStudents.Length; i++) {

            if(theStudents[i] == studentToDelete) {
                theStudents[i] = theStudents[i].Replace(studentToDelete, "");
                deletions++;
            }

        }

        Console.WriteLine("There were " + deletions + " deletions... ");
        return theStudents;

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

    static void runProgram(string[] theStudents) {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do{
            Console.Write("What would you like to do? Type the letter to choose \nL) Load into array \nC) Create students \nR) Read all students \nU) Update a student \nD) Delete a student \nS) Save array to file \nQ) Quit the program \n");
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
                    Console.WriteLine("Loading Students from array...\n");
                    theStudents = readFileIntoArray();
                    continue;

                case 'S':
                    Console.WriteLine("Saving Students from array to file...\n");
                    theStudents = saveArrayIntoFile(theStudents);
                    continue;

                case 'C':
                    Console.WriteLine("Creating Students...\n");                
                    theStudents = createStudents(theStudents);
                    continue;

                case 'R':
                    Console.WriteLine("Reading Students...\n");                
                    theStudents = readStudents(theStudents);
                    continue;

                case 'U':
                    Console.WriteLine("Updating Students...\n");
                    theStudents = updateStudents(theStudents);
                    break;

                case 'D':
                    Console.WriteLine("Deleting Students...\n");
                    theStudents = deleteStudents(theStudents);
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
