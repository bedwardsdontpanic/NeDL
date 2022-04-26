using System;
/*
Calculate the sum, average, min, and max without using an array. 
*/
namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    { 

        Console.Write("How many quizzes?: ");
        int totalNumbers = Convert.ToInt32(Console.ReadLine());       

        double sum = 0;
        double avg;
        double min = 100;
        double max = 0;

        for(int i = 0; i < totalNumbers; i++){
            Console.Write("Quiz " + (i+1) + ": ");
            double nextNum = Convert.ToDouble(Console.ReadLine());

            while(nextNum < 0.0 || nextNum > 100.0){
                Console.WriteLine("Not a valid test score. Enter a valid test score (between 0 and 100)");
                nextNum = Convert.ToInt32(Console.ReadLine());
            }

            sum += nextNum;

            if(nextNum < min){
                min = nextNum;
            }

            if(nextNum > max){
                max = nextNum;
            }

        }

        avg = sum / totalNumbers;

    
        Console.WriteLine("\nThe Average: " + avg);
        Console.WriteLine("The Max: " + max);
        Console.WriteLine("The Min: " + min);

    }


  }
}
