using System;
//        string[] theStudents = File.ReadLines(fileName).ToArray();
namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args) { 

        double[,] twoDArray = get2DNumbers();
        print2DNumbers(twoDArray);
        calculate2DArray(twoDArray);

    }

    static double[] getNumbers() {
        // Ask the user to enter the amount of #s. 
        Console.WriteLine("How many scores for the 1D array?");
        int totalNumbers = Convert.ToInt32(Console.ReadLine());
        double[] theScores = new double[totalNumbers];


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
            theScores[i] = nextNum;

        }

        // Print the #s to the console. 
        foreach(var item in theScores) {
            Console.WriteLine(item);
        }

        return theScores;
    }

    static double[,] get2DNumbers() {

        // Ask the user to enter the amount of #s. 
        Console.WriteLine("How many students?");
        int totalRows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How many scores for each student?");
        int totalColumns = Convert.ToInt32(Console.ReadLine());
        double[,] theScores = new double[totalRows, totalColumns];


        // insert into 2d array
        for(int i = 0; i < totalRows; i++) {

            for(int j = 0; j < totalColumns; j++) {

                Console.Write("Please enter the value of student #" + (i+1) + "'s score on test #" + (j+1) +":  ");
                theScores[i,j] = Convert.ToDouble(Console.ReadLine());
            }

        }

        return theScores;
    }

    static void print2DNumbers(double[,] theArray) {
        
        for(int i=0; i < theArray.GetLength(0); i++) {
            
            Console.Write("Student #" + (i+1) + "'s scores:  ");

            for(int j=0; j < theArray.GetLength(1); j++) {
                Console.Write(theArray[i, j] + "   ");
            }
            
            Console.Write("\n");


        }
        
    }

    static void calculateSingleArray(double[] theNums) {
        
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
        Console.WriteLine("The calculations for the 1D array: ");
        Console.Write("The Average: " + average);
        Console.Write("The Max: " + max);
        Console.Write("The Min: " + min);
    }

    static void calculate2DArray(double[,] theNums) {
        
        int totalRows = theNums.GetLength(0);
        int totalColumns = theNums.GetLength(1);        
        double sum = 0;
        
        for(int i=0; i < totalRows; i++) {
            for(int j=0; j < totalColumns; j++) {
                double theValues = theNums[i,j];
                sum += theValues;
            }

            double avg = sum / totalColumns;
            Console.WriteLine("Student #" + (i+1) + "'s average: " + avg);
            sum = 0;
        }


    }

  }
  
}
