using Core_Api__with_Entityframework.Data;
using Core_Api__with_Entityframework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Api__with_Entityframework.Sevice
{
    public class EmployeeService : IEmployeeService
    {
        ResponseModel responseModel = new ResponseModel();

        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
                _context = context;
        }
        public ResponseModel DeleteEmployeeById(int id)
        {
            var emp=_context.Find<Employee>(id);
            _context.Remove(emp);
            _context.SaveChanges();
            responseModel.Message = "Update Record SeccessFully";
            responseModel.IsSuccess= true;
            return responseModel;

        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp;
            emp=_context.Find<Employee>(id);
            return emp;
        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> empllist;
            empllist=_context.Set<Employee>().ToList();
            return empllist;
        }

        public ResponseModel SaveAddEmployee(Employee employeeModel)
        {
            Employee _temp = GetEmployeeById(employeeModel.EmpId);
            if(_temp != null)
            {
                // Edit and Update 
                _temp.Designation=employeeModel.Designation;
                _temp.EmpName=employeeModel.EmpName;
                _temp.EmpSalary=employeeModel.EmpSalary;
                _context.Update<Employee>(_temp);
                responseModel.Message = "Update Record SeccessFully";

            }
            else
            {
                _context.Add<Employee>(employeeModel);
                responseModel.Message = "Insert Record SeccessFully";
            }
            _context.SaveChanges();
            responseModel.IsSuccess = true;
            return responseModel;
        }
        
    }
}
