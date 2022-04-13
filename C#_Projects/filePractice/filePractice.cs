#pragma warning disable 8604, 8600

class helloworld

{
    public static void Main() {
        runProgram();
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

    static void createStudents() {

        string numInput;

        do {
                Console.Write("How many students would you like to create? ");
                numInput = Console.ReadLine();
        }

        while(validateInt(numInput) == false);

        int numOfStudents = Convert.ToInt16(numInput);

        for(int i = 0; i < numOfStudents; i++) {

            try {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"students.txt", true)) {
                    Console.Write("Enter the students name: ");
                    string studentName = Console.ReadLine();
                    file.WriteLine(studentName);
                }  
                
            }

            catch (Exception exc) {
                Console.WriteLine(exc.ToString());
            }
        }

    }

    static void readStudents() {
        string fileName = @"students.txt";
            try {
                using (StreamReader sr = File.OpenText(fileName)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Console.WriteLine(s);
                    }

                }   
            }

            catch (Exception MyExcep) {
                Console.WriteLine(MyExcep.ToString());
            }
    }

    static void updateStudents() {
        
        Console.Write("Enter the student you'd like to replace: ");
        string studentToReplace = Console.ReadLine();
        
        Console.Write("Enter the student you'd like to make in their place: ");
        string replacementStudent = Console.ReadLine();

        string text = File.ReadAllText("students.txt");
        text = text.Replace(studentToReplace, replacementStudent);
        File.WriteAllText("students.txt", text);

    }

    static void deleteStudents() {
        
        Console.Write("Enter the student you'd like to delete: ");
        string studentToDelete = Console.ReadLine();

        string text = File.ReadAllText("students.txt");
        text = text.Replace(studentToDelete, "");

        File.WriteAllText("students.txt", text);
        

        string[] allLines = File.ReadAllLines(@"students.txt");
        using (StreamWriter sw = new StreamWriter(@"students.txt")) {
            foreach (string line in allLines) {
            if (!string.IsNullOrEmpty(line) && line.Length > 1) {
                sw.WriteLine(line.Replace(" ", string.Empty));
            }
        }
      }
    }

    static bool validateSelection(string s) {

        if(int.TryParse(s, out int x) == true && x >= 1 && x <= 5) {
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

    static void runProgram(){

        string input;
        int selection = 0;
        bool intCheck = false;

        do{
            Console.Write("What would you like to do? Type the # in to choose \n1) Create a student \n2) Read all students \n3) Update a student \n4) Delete a student \n5) Quit the program \n");
            input = Console.ReadLine();
            intCheck = validateSelection(input);
           
           if(intCheck == false){
               Console.WriteLine("Invalid input. Try again...\n");
               continue;
           }

            selection = Convert.ToInt16(input);
            
            switch(selection){
                case 1:
                    Console.WriteLine("Creating Students...\n");                
                    createStudents();
                    continue;

                case 2:
                    Console.WriteLine("Reading Students...\n");
                    readStudents();
                    continue;

                case 3:
                    Console.WriteLine("Updating Students...\n");                
                    updateStudents();
                    continue;

                case 4:
                    Console.WriteLine("Reading Students...\n");                
                    deleteStudents();
                    continue;

                case 5:
                    Console.WriteLine("Exiting program...\n");
                    break;

                default:
                    Console.WriteLine("\n\nInvalid input... Re-enter please.");
                    continue;
            }

        }

        while(selection != 5);
    }
    

}
