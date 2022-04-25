//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class HourlyEmployee: Employee {

    public double hourlyRate {
        get; set;
    } 


    public HourlyEmployee() {
        this.hourlyRate = -1;
    }

    public HourlyEmployee(double hourlyRate, string firstName, string lastName, string employeeType)
        : base(firstName, lastName, employeeType) 
    {
        this.hourlyRate = hourlyRate;
        this.firstName = firstName;
        this.lastName = lastName;
        this.employeeType = employeeType;
    }

    public override double calculateBonus() {
        double bonus = (hourlyRate * 80);
        return bonus;
    }

    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType + ", hourly rate: " + hourlyRate + ", bonus: " + calculateBonus();
    }

    public override string toFileFormat() {
        return firstName + "|" + lastName + "|" + employeeType + "|" + hourlyRate;
    }

}