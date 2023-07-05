using EDigitAPIService.Models;

namespace EDigitAPIService.DAL
{
    public interface IEmployeeDAL
    {
        List<Employee> GetAllEmployees();
        string AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        string UpdateEmployee(int id, Employee employee);
        string DeleteEmployee(int id);


    }
}
