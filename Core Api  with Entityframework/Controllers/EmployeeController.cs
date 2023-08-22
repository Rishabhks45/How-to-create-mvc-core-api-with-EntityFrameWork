using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_Api__with_Entityframework.Models;
using Core_Api__with_Entityframework.Sevice;

namespace Core_Api__with_Entityframework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _EmployeeService { get; set; }
        public EmployeeController(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }
        [HttpGet]
        public IActionResult getAllEmp()
        {
            var emp = _EmployeeService.GetEmployeeList();
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpPost]
        [Route("[action]/id")]
        public IActionResult getEmpById(int id)
        {
            var emp = _EmployeeService.GetEmployeeById(id);
            if (emp == null) { return NotFound(); }
            else
            {
                return Ok(emp);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveEmployee(Employee empp)
        {
            if(ModelState.IsValid)
            {
                var Emp = _EmployeeService.SaveAddEmployee(empp);

            }
            return Ok(empp);

        }
        [HttpPost]
        [Route("[action]/Id")]
        public IActionResult DeleteEmp(int id)
        {
            var did = _EmployeeService.DeleteEmployeeById(id);
            if(did == null)
            {
                return NotFound();
            }
            return Ok(did);
        }
    }
}
