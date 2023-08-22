using Core_Api__with_Entityframework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace Core_Api__with_Entityframework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
         DbSet<Employee> Employees { get; set; }

    }
}
