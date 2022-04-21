//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class HourlyEmployee: Employee {

    private double hourlyRate;

    public double HourlyRate {
          
        get {
            return hourlyRate;    
        }
          
        set {
            hourlyRate = value;
        }
    }

    public HourlyEmployee() {
        this.hourlyRate = -1;
    }

    public HourlyEmployee(double hourlyRate, string firstName, string lastName, string employeeType)
        : base(firstName, lastName, employeeType) 
    {
        this.hourlyRate = hourlyRate;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.EmployeeType = employeeType;
    }

    public override double calculateBonus() {
        double bonus = (hourlyRate * 80);
        return bonus;
    }

    public override string ToString() {
            return "First Name: " + FirstName + ", Last name: " + LastName + ", type: " + EmployeeType + ", hourly rate: " + HourlyRate + ", bonus: " + calculateBonus();
    }

    public override string toFileFormat() {
        return FirstName + "|" + LastName + "|" + EmployeeType + "|" + HourlyRate;
    }

}