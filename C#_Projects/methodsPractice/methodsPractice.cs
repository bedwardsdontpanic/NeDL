using System;

namespace HelloWorld {
  class Program {
    
    static void Main(string[] args) { 
        
        Console.WriteLine("Enter the minimum range: ");
        int minRange = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the max range: ");
        int maxRange = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Getting first int...");
        int firstNum = getValidInt(minRange, maxRange);

        Console.WriteLine("Getting second int...");
        int secondNum = getValidInt(minRange, maxRange);

        Console.WriteLine("The min is: " + MyMin(firstNum, secondNum));
        Console.WriteLine("The max is: " + MyMax(firstNum, secondNum));

/*        
        //Retrieve the #s from the user with the getNumbers method
        double[] theNums = getNumbers();
        // Calculate min, max, avg using 2 different methods (one using built in methods, one using a loop) 
        mathWithFunctions(theNums);
        mathWithLoops(theNums);
*/
    }


    
    static double[] getNumbers() {
        // Ask the user to enter the amount of #s. 
        Console.WriteLine("How many numbers?");
        int totalNumbers = Convert.ToInt32(Console.ReadLine());
        double[] theNums = new double[totalNumbers];


        // Retrieve the #s from the user.
        for(int i = 0; i < totalNumbers; i++) {
        
            Console.Write("Number " + (i+1) +": ");
            double nextNum = Convert.ToDouble(Console.ReadLine());
            
            // ensure the users input is between 0 and 100
            while(nextNum < 0.0 || nextNum > 100.0) {
                Console.WriteLine("Not a valid test score. Enter a valid test score (between 0 and 100)");
                nextNum = Convert.ToInt32(Console.ReadLine());
            }

            // insert into the array
            theNums[i] = nextNum;

        }


        // Print the #s to the console. 
        foreach(var item in theNums) {
            Console.WriteLine(item);
        }

        return theNums;

    }

    // Use the mathematical functions to determine the results 
    static void mathWithFunctions(double[] theNums) {

        double sum = theNums.Sum();
        double average = theNums.Average();        
        double max = theNums.Max();
        double min = theNums.Min();

        Console.WriteLine("USING FUNCTIONS...");
        Console.WriteLine("The Sum: " + sum);
        Console.WriteLine("The Average: " + average);
        Console.WriteLine("The Max: " + max);
        Console.WriteLine("The Min: " + min);

    }


    //Determine the results using a loop. 
    static void mathWithLoops(double[] theNums) {
        
        double sum = 0;
        double min = theNums[0];
        double max = theNums[0];
        double average;

        // Use a foreach since the # of numbers can vary. 
        foreach (var item in theNums) {
            sum += item;
            
            if(item < min) {
                min = item;
            }

            if(item > max) {
                max = item;
            }

        }

        average = sum / theNums.Count();
        Console.WriteLine("USING A LOOP...");
        Console.WriteLine("The Sum: " + sum);
        Console.WriteLine("The Average: " + average);
        Console.WriteLine("The Max: " + max);
        Console.WriteLine("The Min: " + min);
    }


    static int MyMin(int x, int y) {
        if(x > y) {
            return y;
        }
        
        else {
            return x;
        }
    }

    static int MyMax(int x, int y) {
        if(x < y) {
            return y;
        }
        
        else {
            return x;
        }
    }


    static int getValidInt(int lowRangeValue, int highRangeRangeValue) {

        Console.WriteLine("The range is between " + lowRangeValue + " and " + highRangeRangeValue + ". Please enter your int: ");
        int validInt = Convert.ToInt32(Console.ReadLine());

        while(validInt < lowRangeValue || validInt > highRangeRangeValue){
            Console.WriteLine("Outside the range. Enter again: ");
            validInt = Convert.ToInt32(Console.ReadLine());
        }

        return validInt;

    }

  }
}
