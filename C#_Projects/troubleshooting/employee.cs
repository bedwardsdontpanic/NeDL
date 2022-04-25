using System;

namespace Competency //same namespace as Program
{
    class Employees //base class
    {
        public string firstName;
        public string lastName;
        public char eType;
        public int getSalary
        {
            get;
            set;
        }
        public double getHourly
        {
            get;
            set;
        }
        public Employees() //call the object class again; constructor
        {
            firstName = null; 
            lastName = null;
            eType = '\0';
            getSalary = 0;
            getHourly = 0;
        }
    public Employees (string newFirstName, string newLastName, char newEType)
    {
        firstName = newFirstName;
        lastName = newLastName;
        eType = newEType;

    }
    public override string ToString() //overwrites the values to strings
    {
        return "The employees name is: " + firstName + " " + lastName + " and there employee type is: " + eType;
    }
  }
}