using System;
#pragma warning disable 8604
namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args) { 

        int ans;

        // Use a do-while loop to repeat the program until user ends it. 
        do{
            (int baseInt, int beginExponent, int endExponent) = getVars();

            for(int i = beginExponent; i <= endExponent; i++) {
                Console.WriteLine(baseInt + " raised to the " + i + " power: " + Power(baseInt, i));
            }

            Console.WriteLine("Would you like to repeat the program? 1 for yes, 2 for no. ");
            ans = Int32.Parse(Console.ReadLine());

            Console.WriteLine("You chose " + ans + "...");

            if(ans != 1 && ans != 2){
                Console.WriteLine("Invalid input. Repeating program...");
                continue;
            }
        }

        while(ans != 2); 

    }



    static (int, int, int) getVars(){
        int baseInt;
        int beginExponent;
        int endExponent;

        // Get Base. Ensure the value is >= 1
        Console.Write("Enter your base: ");
        baseInt = Int32.Parse(Console.ReadLine());
        
        while(validExpInput(baseInt) == false){
            Console.Write("Invalid input. Ensure your base is >= 1: ");
            baseInt = Int32.Parse(Console.ReadLine());            
        }

        
        // Get beginning exp. Ensure the value is >= 1
        Console.Write("Enter your beginning exponent: ");
        beginExponent = Int32.Parse(Console.ReadLine());

        while(validExpInput(beginExponent) == false){
            Console.Write("Invalid input. Ensure your beginning exponent is >= 1: "); 
            beginExponent = Int32.Parse(Console.ReadLine());
        }

        
        // Get ending exp. Ensure the value is >= 1
        Console.Write("Enter your ending exponent: ");
        endExponent = Int32.Parse(Console.ReadLine());

        while(validExpInput(endExponent) == false || endExponent < beginExponent){
            Console.Write("Invalid input. Ensure your ending exponent is >= 1 and is also greater than your ending exponent: "); 
            endExponent = Int32.Parse(Console.ReadLine());
        }

        // Return the 3 integers to use for the calculating exponents program. 
        return (baseInt, beginExponent, endExponent);

    }



    //Takes in a base and calculates it to the power of an inputted exponent. 
    static int Power(int baseInt, int exponent) {
        
        int result = 1;
        for (int i=1; i <= exponent; i++) {
            result = baseInt * result;
        }

        // baseInt ^ exponent
        return result;

    }



    // Ensure the user inputted a value >= 1. 
    static Boolean validExpInput(int x) {
        if(x >= 1) {
            return true;
        }
        else {
            return false;
        }

    }



  }
}
