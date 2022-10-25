using EmployeeAPI.Models;
namespace EmployeeAPI.Services;

public class EmployeeService
{
    //list of employees to store the entered data
    static List<Employee> employeesList { get; }
    //next employee record
    static int nextEmpId = 3;

    //Constractour
    static EmployeeService()
    {
        employeesList = new List<Employee>()
        {
            new Employee{ ID=1, Name="Ahmed",Title="Developer", Salary=3000 },
            new Employee{ ID=2, Name="Mohamed",Title="CEO", Salary=4000 },
        };
    }

    ////////////////////////////////////////////////// <summary>////////////////////////////
    ////////////////////////////////////// Methods ////////////////////////////////////////
    ////////////////////////////////////////////////// </summary>/////////////////////////


    //Get all data from API, as a List , then can do all methods
    public static List<Employee> GetAll()
    {
        return employeesList;
    }

    //Get a specific Employee by ID
    public static Employee Get(int id)
    {
        return employeesList.FirstOrDefault(p => p.ID == id);
    }


    //Add an Employee to list
    public static void Add(Employee employee) 
    {
        //First,increase the next employee id by one
        employee.ID = nextEmpId++;
        //then add the new employee ,which get from the user, with its id 
        employeesList.Add(employee);
    }

    //Update a specific employee by ID
    public static void Update(Employee employee)
    {
        var index = employeesList.FindIndex(p => p.ID == employee.ID);
        if (index == -1)
            return;
        employeesList[index] = employee;
    }

    //Delete a specific employee by ID
    public static void Delete(int id) 
    {
        //store the id in a variable 
        var employee = Get(id);
        //when the id is null return nothing,or
        if (employee is null)
            return;
        //remove from the list that employee, when we get id
        employeesList.Remove(employee);
    }
}