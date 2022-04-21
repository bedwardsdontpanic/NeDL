//SalaryEmployee (annual salary; constructors, calculate bonus, toString

//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class SalaryEmployee: Employee {

    private double annualSalary;

    public double AnnualSalary {
          
        get {
            return annualSalary;    
        }
          
        set {
            annualSalary = value;
        }
    }

    public SalaryEmployee() {
        this.annualSalary = -1;
    }

    public SalaryEmployee(double annualSalary, string firstName, string lastName, string employeeType)
        : base(firstName, lastName, employeeType) {
        this.AnnualSalary = annualSalary;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.EmployeeType = employeeType;
    }

    public override double calculateBonus() {
        double bonus = (annualSalary * 0.1);
        return bonus;
    }

    public override string ToString() {
            return "First Name: " + FirstName + ", Last name: " + LastName + ", type: " + EmployeeType + ", annual salary: " + AnnualSalary + ", bonus: "  + calculateBonus();
    }

    public override string toFileFormat() {
        return FirstName + "|" + LastName + "|" + EmployeeType + "|" + AnnualSalary;
    }

}