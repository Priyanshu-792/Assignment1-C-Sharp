using System;

class Employee
{
    private int Id;
    private string Name;
    private string DepartmentName;

    // Event declaration
    public event EventHandler<string> MethodCalled;

    // Constructor
    public Employee(int id, string name, string departmentName)
    {
        Id = id;
        Name = name;
        DepartmentName = departmentName;
    }

 
    public int GetId()
    {
        // Invoke event
        OnMethodCalled("GetId() method called");
        return Id;
    }

    public string GetName()
    {
        // Invoke event
        OnMethodCalled("GetName() method called");
        return Name;
    }

    public string GetDepartmentName()
    {
        // Invoke event
        OnMethodCalled("GetDepartmentName() method called");
        return DepartmentName;
    }

    // Method to invoke the event
    protected virtual void OnMethodCalled(string message)
    {
        MethodCalled?.Invoke(this, message); // Event is fired here
    }

    // Overloaded methods to update properties

    // UpdateId() method implementation
    public void UpdateId(int newId)
    {
        // Invoke event
        OnMethodCalled("UpdateId() method called");
        Id = newId;
    }

    // UpdateName() method implementation
    public void UpdateName(string newName)
    {
        // Invoke event
        OnMethodCalled("UpdateName() method called");
        Name = newName;
    }

    // UpdateDepartmentName() method implementation
    public void UpdateDepartmentName(string newDepartmentName)
    {
     
        OnMethodCalled("UpdateDepartmentName() method called");
        DepartmentName = newDepartmentName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an Employee object
        Console.WriteLine("Enter Employee details:");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Department Name: ");
        string departmentName = Console.ReadLine();

        Employee emp = new Employee(id, name, departmentName);

      
        emp.MethodCalled += (sender, message) => Console.WriteLine(message);

        // Print properties
        Console.WriteLine("Employee Details:");
        Console.WriteLine("Id: " + emp.GetId());
        Console.WriteLine("Name: " + emp.GetName());
        Console.WriteLine("Department Name: " + emp.GetDepartmentName());

        // Update properties
        Console.WriteLine("\nEnter new details for the employee:");

        Console.Write("New Id: ");
        emp.UpdateId(int.Parse(Console.ReadLine()));

        Console.Write("New Name: ");
        emp.UpdateName(Console.ReadLine());

        Console.Write("New Department Name: ");
        emp.UpdateDepartmentName(Console.ReadLine());

        // Print updated properties
        Console.WriteLine("\nUpdated Employee Details:");
        Console.WriteLine("Id: " + emp.GetId());
        Console.WriteLine("Name: " + emp.GetName());
        Console.WriteLine("Department Name: " + emp.GetDepartmentName());
    }
}
