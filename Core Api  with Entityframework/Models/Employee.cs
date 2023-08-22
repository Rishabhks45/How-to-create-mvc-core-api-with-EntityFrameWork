using System.ComponentModel.DataAnnotations;

namespace Core_Api__with_Entityframework.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
        public string Designation { get; set; }
    }
}
