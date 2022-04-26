//Employee (last name, first name, employee type; constructors, calculate bonus, toString)

class Employee: IFileFormat {

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

    virtual public string toFileFormat() {
        return "";
    }

    public override string ToString() {
            return "First Name: " + firstName + ", Last name: " + lastName + ", type: " + employeeType;
    }

}