using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class MyService
    {
        private readonly DapperDBContext dbContext;

        public MyService(DapperDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> emp= await dbContext.Employees.FromSqlRaw("EXEC EmployeeViewAll").ToListAsync();
            return emp ?? new List<Employee>();
        }
    } 
}
