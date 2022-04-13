// See https://aka.ms/new-console-template for more information
using System;

/*
Total money. Ask for # of pennies, # of nickels, Dimes, quarters
*/


namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    { 
      Console.WriteLine("Enter # of pennies: ");
      string pennies = Console.ReadLine();
      double penniesTotal = Int32.Parse(pennies) * 0.01;

      Console.WriteLine("Enter # of nickels: ");
      string nickels = Console.ReadLine();
      double nickelsTotal = Int32.Parse(nickels) * 0.05;

      Console.WriteLine("Enter # of dimes: ");
      string dimes = Console.ReadLine();
      double dimesTotal = Int32.Parse(dimes) * 0.10;

      Console.WriteLine("Enter # of quarters: ");
      string quarters = Console.ReadLine();
      double quartersTotal = Int32.Parse(quarters) * 0.25;


      double totalValue = Math.Round(penniesTotal + nickelsTotal + dimesTotal + quartersTotal, 2);
      Console.WriteLine("total value: " + totalValue);
      
    }
  }
}

