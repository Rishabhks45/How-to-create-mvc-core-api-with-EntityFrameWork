using Core_Api__with_Entityframework.Models;

namespace Core_Api__with_Entityframework.Sevice
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
        ResponseModel SaveAddEmployee(Employee employeeModel);
        ResponseModel DeleteEmployeeById(int id);

    }
}
