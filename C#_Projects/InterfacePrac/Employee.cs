//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

public class Employee {

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

    public virtual double calculateBonus() {
        double bonus;
        bonus = -1;
        return bonus;
    }

    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType;
    }

    public virtual string toFileFormat() {
        return "";
    }

}