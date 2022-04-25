//SalaryEmployee (annual salary; constructors, calculate bonus, toString

//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

class SalaryEmployee: Employee {

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

    public override double getBonus() // implementation of abstract method
    {
        return annualSalary * .1;
    }


    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType + ", annual salary: " + annualSalary + ", bonus: "  + getBonus();
    }

    public override string toFileFormat() {
        return firstName + "|" + lastName + "|" + employeeType + "|" + annualSalary;
    }

}