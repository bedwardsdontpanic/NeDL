using System;

namespace Competency //same namespace as Program
{
    class Hourly: Employees //base class
    {
        private double hourlyRate;
        public double HourlyRate;
        private double hourlyBonus;//remove here and make a method; try this once done
        public double HourlyBonus;
        public double getHourly
        {
            get
            {
                return Convert.ToDouble(HourlyRate);
            }
            set{
                HourlyRate = getHourly;
            }
        }
        public Hourly() //call the object class again; constructor
        {
            HourlyRate = 0; 
        }
    public Hourly (string newFirstName, string newLastName, char newEType, double newHourlyRate): base (newFirstName, newLastName, newEType) 
    {
        hourlyRate = newHourlyRate;
        hourlyBonus = hourlyRate*80;

    }
    public override string ToString() //overwrites the values to strings
    {
        return "The employees name is: " + firstName + " " + lastName + ", their hourly rate is: " + hourlyRate + " dollars and their bonus would be: " + hourlyBonus;
    }
  }
}