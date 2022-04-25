//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

abstract class Employee {

    public string firstName{
        get; set;
    }
    public string lastName{
        get; set;
    }
    public string employeeType{
        get; set;
    }

    public Employee() {
        this.firstName = "";
        this.lastName = "";
        this.employeeType = "";
    }

    public Employee(string firstName, string lastName, string employeeType) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.employeeType = employeeType;
    }

    public abstract double getBonus();


    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType;
    }

    public abstract string toFileFormat();

}