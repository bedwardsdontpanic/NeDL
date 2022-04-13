using System;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    { 
      Console.WriteLine("Enter # of feet: ");
      string feet = Console.ReadLine();
      int feetInt = Int32.Parse(feet);


      while(feetInt <= 0){
        Console.WriteLine("Not a valid integer. Please enter a valid integer. ");
        feet = Console.ReadLine();
        feetInt = Int32.Parse(feet);
      }
       

      int total = feetInt * 12;
      Console.WriteLine(total);
    
    }
  }
}
