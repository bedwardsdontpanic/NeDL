using System;

namespace Competency //must be the same namespace througout
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validUserChoice = false;
            string userChoice;
            string fileName = @"EmployeesList.txt";

        Employees[] EmployeeArray = new Employees[25]; //Employee array create

            do 
        {
            do
        {
        //initialize variables
        validUserChoice = false;
        //provide the user a menu of options
        Console.WriteLine("What would you like to do to the array today?");
        Console.WriteLine("L: Load the file into an array.");
        Console.WriteLine("S: Store the array in a file");
        Console.WriteLine("C: Add a name to the array.");
        Console.WriteLine("R: Read a name from your array.");
        Console.WriteLine("Q: Quit the program.");
        
        //get a valid user option (valid means it is on menu
        userChoice = Console.ReadLine();

        validUserChoice = (userChoice == "L" || userChoice == "l" 
                          ||userChoice == "S" || userChoice == "s" 
                          || userChoice == "C" || userChoice == "c" 
                          || userChoice == "R" || userChoice == "r"
                          || userChoice == "Q" || userChoice == "q");

        if(!validUserChoice)
        {
          Console.WriteLine("Please enter a valid option");
        }

          } while (!validUserChoice);

/*             Employees newEmployee = new Employees ("John", "Smith", 'S');
            //Console.WriteLine(newEmployee);
            Salary newSalary = new Salary ("Hayley", "Griffin", 'S', 85000);
            //Console.WriteLine(newSalary);
            Hourly newHourly = new Hourly ("Derek", "Loseke", 'H', 20.50);
            Salary newSalary2 = new Salary ("Karen", "Johnson", 'S', 65000);
            Salary newSalary3 = new Salary ("Jay", "Leno", 'S', 465000);
            Salary newSalary4 = new Salary ("Kristen", "Bell", 'S', 470000);
            Hourly newHourly2 = new Hourly ("Chris", "Hemsworth", 'H', 30.50);
            Hourly newHourly3 = new Hourly ("Kendall", "Jenner", 'H', 39.00);
            //Console.WriteLine(newHourly);
            EmployeeArray[10] = newEmployee; //put obj we already created in the Array (Line9)
            EmployeeArray[15] = new Hourly ("Steve", "Carson", 'H', 25.00);
            EmployeeArray[19] = newSalary; //same as above
            EmployeeArray[3] = newSalary2;
            EmployeeArray[6] = newSalary3;
            EmployeeArray[0] = newSalary4;
            EmployeeArray[22] = newHourly;
            EmployeeArray[17] = newHourly2;
            EmployeeArray[9] = newHourly3; */
 
            //in the L section
        if(userChoice == "L" || userChoice == "l")
        {
         using (StreamReader sr = File.OpenText("EmployeesList.txt"))
         {
            int index = 0;
            char eType;
            string firstName;
            string lastName;

           while ((firstName = sr.ReadLine()) != null) //sets first line of the file to lastName
            {
                //firstName = sr.ReadLine();
                Console.WriteLine(firstName);

                lastName = sr.ReadLine(); //sets the second line of the file to lastName
                Console.WriteLine(lastName);

                eType = Convert.ToChar(sr.ReadLine()); //sets the third line of the file to eType
                Console.WriteLine(eType);

              if(eType == 'S' || eType == 's')
              {
                    int salary = Convert.ToInt32(sr.ReadLine());  //if salary, sets fourth line of the file to salary
                    Console.WriteLine(salary);
                    EmployeeArray[index] = new Salary (firstName, lastName, eType, salary);
              }
              else if (eType == 'H' || eType =='h')
              {
                  double hourlyrate = Convert.ToDouble(sr.ReadLine());
                  Console.WriteLine(hourlyrate);
                  EmployeeArray[index] = new Hourly (firstName, lastName, eType, hourlyrate);
              }
 
              index = index +1;
            } 
            Console.WriteLine("");
         }
        } //close if statement
 
        //in the S section - save the file





        else if (userChoice == "S" || userChoice == "s")
         {
            int index;
            char eType = '\0';
            string firstName;
            string lastName;
            int AnnualSalary;
          Console.WriteLine("In the S/s area");
          //delete the file if it exists; for Ratings
          if (File.Exists(fileName))
          {
            File.Delete(fileName);
          }

          Console.WriteLine(EmployeeArray.Length);
          using(StreamWriter fileStr = File.CreateText(fileName))
          { //rewrite the data
            for (index = 0; index < EmployeeArray.Length; index++)
            {

              if(EmployeeArray[index] != null && (EmployeeArray[index].eType == 'S' || EmployeeArray[index].eType == 's'))
              {
                fileStr.WriteLine(EmployeeArray[index].firstName);
                fileStr.WriteLine(EmployeeArray[index].lastName);
                fileStr.WriteLine(EmployeeArray[index].eType);
                fileStr.WriteLine(EmployeeArray[index].getSalary);
              }
            else if(EmployeeArray[index] != null && (EmployeeArray[index].eType == 'H' || EmployeeArray[index].eType == 'h'))
            {
                fileStr.WriteLine(EmployeeArray[index].firstName);
                fileStr.WriteLine(EmployeeArray[index].lastName);
                fileStr.WriteLine(EmployeeArray[index].eType);
                fileStr.WriteLine(EmployeeArray[index].getHourly);  
            }
          }
          Console.WriteLine(fileName + " has been saved");
          } 
         }









        //now in the R section
        else if(userChoice == "R" || userChoice == "r")
        {
          Console.WriteLine("in the R/r area");

         for (int index = 0; index < EmployeeArray.Length; index++)
          {
            if(EmployeeArray[index] != null)
            {
               Console.WriteLine(EmployeeArray[index]);
            } 
          }
            Console.WriteLine("");
        }
        //create an employee if there is space
        else if(userChoice == "C" || userChoice == "c")
        { 
           int index = 0;
           string firstName = null;
           string lastName = null;
           int AnnualSalary = 0;
           double HourlyRate = 0;
 

          //gets the employee type to base the questions below on
          Console.WriteLine("What is the employees employment type? S or H");
            char eType = Convert.ToChar(Console.ReadLine());
            if(eType == 'S' || eType == 's') //statements for salary employees
            {
                Console.WriteLine("What is the salaried employees first name?");
                firstName = Console.ReadLine();
                Console.WriteLine("What is the salaried employees last name?");
                lastName = Console.ReadLine();
                Console.WriteLine("What is their salary?");
                AnnualSalary = Convert.ToInt32(Console.ReadLine());
            }
            else if (eType == 'H' || eType == 'h') //gives the statemtns for hourly employees
                {
                Console.WriteLine("What is the hourly employees first name?");
                firstName = Console.ReadLine();
                Console.WriteLine("What is the hourly employees last name?");
                lastName = Console.ReadLine();
                Console.WriteLine("What is their hourly rate?");
                HourlyRate = Convert.ToDouble(Console.ReadLine());   
                }
          
           bool found = false; 
          //index to add it new employee to the array
          for (index = 0; index < EmployeeArray.Length; index++)
          {
             if((EmployeeArray[index] == null) && found == false) 
            {
              if(eType == 'S' || eType == 's') //checks for S
              {
              EmployeeArray[index] = new Salary(firstName, lastName, eType, AnnualSalary); 
              found = true;
              }
              else //checks for not
              EmployeeArray[index] = new Hourly(firstName, lastName, eType, HourlyRate);
              found = true;

              Console.WriteLine(EmployeeArray[index]); 
            } //closefor loop 
          } //close first for loop
            Console.WriteLine(""); 

            if (found == false) 
          {
            Console.WriteLine("There is no space to add a new employee!");
            Console.WriteLine("");
          }//close if loop
        }//close else if 
        } while (!(userChoice == "Q" || userChoice == "q"));
      }
    }
}