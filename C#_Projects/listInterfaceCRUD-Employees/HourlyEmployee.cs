//HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

class HourlyEmployee: Employee, IGetBonus, IFileFormat {

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

    public double getBonus() {
        return hourlyRate * 80;
    }

    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType + ", hourly rate: " + hourlyRate + ", bonus: " + getBonus();
    }

    public override string toFileFormat() {
        return firstName + "|" + lastName + "|" + employeeType + "|" + hourlyRate;
    }

}