//SalaryEmployee (annual salary; constructors, calculate bonus, toString

//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class SalaryEmployee: Employee {

    public double annualSalary {
        get; set; 
    }


    public SalaryEmployee() {
        this.annualSalary = -1;
    }

    public SalaryEmployee(double annualSalary, string firstName, string lastName, string employeeType)
        : base(firstName, lastName, employeeType) {
        this.annualSalary = annualSalary;
        this.firstName = firstName;
        this.lastName = lastName;
        this.employeeType = employeeType;
    }

    public override double calculateBonus() {
        double bonus = (annualSalary * 0.1);
        return bonus;
    }

    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType + ", annual salary: " + annualSalary + ", bonus: "  + calculateBonus();
    }

    public override string toFileFormat() {
        return firstName + "|" + lastName + "|" + employeeType + "|" + annualSalary;
    }

}