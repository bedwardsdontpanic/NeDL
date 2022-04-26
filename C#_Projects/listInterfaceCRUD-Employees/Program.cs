#pragma warning disable 8604, 8600, 8601, 8602

class helloworld {
    public static void Main() {
        
        List<Employee> theEmployees = new List<Employee>();
        
        
        runProgram(theEmployees);

    }

    static List<Employee> loadFileIntoList(List<Employee> theEmployees) {
        
        string[] theText = File.ReadLines(@"Employees.txt").ToArray();

        for(int i = 0; i < theText.Count(); i++) {
            if(theText[i] != "" && theText[i] != null) {
                string[] splitit = theText[i].Split('|');

                if(splitit[2] == "hourly"){
                    HourlyEmployee newEmployee = new HourlyEmployee(Convert.ToDouble(splitit[3]), splitit[0], splitit[1], splitit[2]);
                    theEmployees.Add(newEmployee);
                }
                else {
                    SalaryEmployee newEmployee = new SalaryEmployee(Convert.ToDouble(splitit[3]), splitit[0], splitit[1], splitit[2]);
                    theEmployees.Add(newEmployee);
                }
            }
        }

        return theEmployees;
    } 

    static List<Employee> saveListIntoFile(List<Employee> theEmployees) {
        
        using(StreamWriter SW = new StreamWriter("employees.txt")) {
        
            foreach(Employee emp in theEmployees) {
                SW.WriteLine(emp.toFileFormat());
            }
        }

        return theEmployees;
    }

    static List<Employee> createEmployee(List<Employee> theEmployees) {
        // Get name of new employee and validate
        string newEmployeeFirstName;
        do{
            Console.Write("Enter the first name of the new employee: ");
            newEmployeeFirstName = Console.ReadLine();
        }
        while(validateName(newEmployeeFirstName) == false);

        // Get name of new employee and validate
        string newEmployeeLastName;
        do{
            Console.Write("Enter the last name of the new employee: ");
            newEmployeeLastName = Console.ReadLine();
        }
        while(validateName(newEmployeeLastName) == false);

        // Get name of new employee and validate
        string newEmployeeType;

        do{
            Console.Write("Enter the type of the employee " + newEmployeeFirstName + " " + newEmployeeLastName + " is: (H for Hourly, S for Salary):  ");
            newEmployeeType = Console.ReadLine();

        }
        while(validateType(newEmployeeType) == "");
        
        newEmployeeType = validateType(newEmployeeType);

        // Get rating of new employee and validate
        string wageEntry;
        do {
            Console.Write("Enter the wage for the new " + newEmployeeType + " rate employee type named " + newEmployeeFirstName + " " + newEmployeeLastName +":  ");
            wageEntry = Console.ReadLine();
        }
        while(validateDouble(wageEntry)==false);
        
        double newEmployeeWage = Convert.ToDouble(wageEntry);

        if(newEmployeeType == "hourly"){
            HourlyEmployee theNewEmployee = new HourlyEmployee(newEmployeeWage, newEmployeeFirstName, newEmployeeLastName, newEmployeeType);
            theEmployees.Add(theNewEmployee);
        }

        else {
            SalaryEmployee theNewEmployee = new SalaryEmployee(newEmployeeWage, newEmployeeFirstName, newEmployeeLastName, newEmployeeType);
            theEmployees.Add(theNewEmployee);
        }

        Console.WriteLine(newEmployeeFirstName + " has been created...\n");

        return theEmployees;

    }

    static List<Employee> readEmployees(List<Employee> theEmployees) {
        
        foreach(Employee theEmployee in theEmployees){
            Console.WriteLine(theEmployee);
        }

        Console.WriteLine("Returning to main menu...\n");
        return theEmployees;
    }

    static List<Employee> updateEmployee(List<Employee> theEmployees) {
        
        Console.Write("Enter the first and last name of the employee you'd like to replace, separated by a space:  ");
        string employeeToReplace = Console.ReadLine();
        
        
        // Get name of new employee and validate
        string newEmployeeFirstName;
        do{
            Console.Write("Enter the first name of the new employee: ");
            newEmployeeFirstName = Console.ReadLine();
        }
        while(validateName(newEmployeeFirstName) == false);

        // Get name of new employee and validate
        string newEmployeeLastName;
        do{
            Console.Write("Enter the last name of the new employee: ");
            newEmployeeLastName = Console.ReadLine();
        }
        while(validateName(newEmployeeLastName) == false);

        // Get name of new employee and validate
        string newEmployeeType;

        do{
            Console.Write("Enter the type of the employee " + newEmployeeFirstName + " " + newEmployeeLastName + " is: (H for Hourly, S for Salary):  ");
            newEmployeeType = Console.ReadLine();

        }
        while(validateType(newEmployeeType) == "");
        
        newEmployeeType = validateType(newEmployeeType);

        // Get rating of new employee and validate
        string wageEntry;
        do {
            Console.Write("Enter the wage for the new " + newEmployeeType + " rate employee type named " + newEmployeeFirstName + " " + newEmployeeLastName +":  ");
            wageEntry = Console.ReadLine();
        }
        while(validateDouble(wageEntry)==false);
        
        double newEmployeeWage = Convert.ToDouble(wageEntry);

        int numRemoved = theEmployees.RemoveAll(x => x.firstName + " " + x.lastName == employeeToReplace);



        if(newEmployeeType == "hourly"){
            HourlyEmployee newEmp = new HourlyEmployee(newEmployeeWage, newEmployeeFirstName, newEmployeeLastName, newEmployeeType);
            for (int i =0; i < numRemoved; i++) {
                theEmployees.Add(newEmp);
            }
        }
        else{
            SalaryEmployee newEmp = new SalaryEmployee(newEmployeeWage, newEmployeeFirstName, newEmployeeLastName, newEmployeeType);
            for (int i =0; i < numRemoved; i++) {
                theEmployees.Add(newEmp);
            }
        }


        Console.WriteLine("There were " + numRemoved + " replacement(s) made... Returning to main menu...\n");
        return theEmployees;
    }

    static List<Employee> deleteEmployee(List<Employee> theEmployees) {
        
        Console.Write("Enter the employee you'd like to delete: ");
        string employeeToDelete = Console.ReadLine();
        int deletions = theEmployees.RemoveAll(x => x.firstName + " " + x.lastName == employeeToDelete);

        Console.WriteLine("There were " + deletions + " deletion(s)... Returning to main menu...\n");
        return theEmployees;

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

    static bool validateDouble(string s) {

        if(double.TryParse(s, out double x) == true && x >= 1) {
            return true;
        }

        else {
            Console.WriteLine("Invalid input. Try again... ");
            return false;
        }
    }

    static bool validateName(string s) {

        if((s.Contains('|')) == true) {
            Console.WriteLine("Why would you put a pipe in your employee's name? Don't do that. ");
            return false;
        }

        else if(s =="" || s == null) {
            Console.WriteLine("Please be sure to enter a value.. ");
            return false;
        }

        else {
            return true;
        }
    }

    static string validateType(string s) {

        if(s == "H" || s =="h") {
            return "hourly";
        }

        else if(s =="S" || s == "s") {
            return "salary";
        }

        else {
            Console.WriteLine("Incorrect input. Try again... ");
            return "";
        }
    }
    static void runProgram(List<Employee> theEmployees) {

        string input;
        char selection = 'z';
        bool charCheck = false;

        do {
            Console.Write("What would you like to do? Type the letter to choose \nL) Load into list \nC) Create Employee \nR) Read all Employee \nU) Update a employee \nD) Delete a employee \nS) Save list to file \nQ) Quit the program \n");
            input = Console.ReadLine();
            input = input.ToUpper();
            charCheck = validateSelection(input);
           
           if(charCheck == false) {
               continue;
            }

            selection = Convert.ToChar(input);

            switch(selection) {
                case 'L':
                    Console.WriteLine("Loading Employee from list...\n");
                    theEmployees = loadFileIntoList(theEmployees);
                    continue;

                case 'S':
                    Console.WriteLine("Saving Employee from list to file...\n");
                    theEmployees = saveListIntoFile(theEmployees);
                    continue;

                case 'C':
                    Console.WriteLine("Creating Employee...\n");                
                    theEmployees = createEmployee(theEmployees);
                    continue;

                case 'R':
                    Console.WriteLine("Reading Employee...");                
                    theEmployees = readEmployees(theEmployees);
                    continue;

                case 'U':
                    Console.WriteLine("Updating Employee...\n");
                    theEmployees = updateEmployee(theEmployees);
                    break;

                case 'D':
                    Console.WriteLine("Deleting Employee...\n");
                    theEmployees = deleteEmployee(theEmployees);
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


