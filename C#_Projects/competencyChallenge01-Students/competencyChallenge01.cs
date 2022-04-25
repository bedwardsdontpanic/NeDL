using System;
#pragma warning disable 8604, 8600
namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    { 
        
        string numOfStudentsInput;

        do{
            Console.WriteLine("How many students? (Please ensure this is an integer and greater than 1. If not, you will be asked to enter again. )");
            numOfStudentsInput = Console.ReadLine();
            Console.WriteLine();
        }

        while(validateInteger(numOfStudentsInput) == false);

        int numOfStudents = Convert.ToInt32(numOfStudentsInput);

        for(int i = 1; i <= numOfStudents; i++){
            double hwScore = calculateStudentGrades(i, "Homework", 5);
            double quizScore = calculateStudentGrades(i, "Quizzes", 3);
            double examScore = calculateStudentGrades(i, "Exams", 2);
            double finalScore = calculatedWeightedGrade(hwScore, quizScore, examScore);
            Console.WriteLine("Student #" + i + " has an average of " + hwScore + " on HW, " + quizScore + " on quizzes, " + examScore + " on exams... \n");
            char letterGrade = assignLetterGrade(finalScore);
            Console.Write("Student #" + i + "'s final letter grade:  " + letterGrade + "\n\n\n");
        }
    
    }

    static bool validateInteger(string s) {

        if(int.TryParse(s, out int x) == true && x >= 1){
            return true;
        }

        else {
            return false;
        }
        
    }

    static bool validateDouble(string s){

        if(double.TryParse(s, out double x) == true && x >= 1 &&  x<= 100) {
            return true;
        }

        else {
            return false;
        }
        
    }    

    static double calculateStudentGrades(int studentNumber, string gradeType, int numOfGrades) {

        double finalScore = 0;
        string nextScoreInput;
        double nextScore;

        Console.WriteLine("Please input the grade for each "+ gradeType + " for Student # "+ studentNumber +". Ensure this is a valid number greater than 0, or you will be asked to input your entry again. ");
        
        
        for(int i = 1; i<=numOfGrades; i++){
            
            do{
                Console.Write("Score of " + gradeType + "#" + i + ":  ");
                nextScoreInput = Console.ReadLine();
            } 

            while(validateDouble(nextScoreInput) == false);

        nextScore = Convert.ToDouble(nextScoreInput);
        finalScore += nextScore;

        }

        double finalAverage = finalScore / numOfGrades;
        Console.WriteLine("Final average of " + gradeType +" for student # " + studentNumber +":  " + finalAverage + "\n");
        return finalAverage;

    }

    static double calculatedWeightedGrade(double homeWorkScore, double quizScore, double examScore) {
        double finalGrade = (homeWorkScore * 0.5) + (quizScore * 0.3) + (examScore *0.2);
        Console.WriteLine("Final numerical grade:  " + finalGrade);
        return finalGrade;
    }

    static char assignLetterGrade(double finalGrade) {

        char finalLetterGrade;

        if(finalGrade > 90) {
            finalLetterGrade = 'A';
        }

        else if(finalGrade > 80) {
            finalLetterGrade = 'B';
        }

        else if(finalGrade > 70) {
            finalLetterGrade = 'C';
        }

        else if(finalGrade > 60) {
            finalLetterGrade = 'D';
        }

        else {
            finalLetterGrade = 'F';     
        }

        return finalLetterGrade;

    }

  }
}
