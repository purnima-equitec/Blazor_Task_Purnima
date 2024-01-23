using BlazorApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

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
            List<Employee> emp = await dbContext.Employees.FromSqlRaw("EXEC EmployeeViewAll").ToListAsync();
            return emp ?? new List<Employee>();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await dbContext.Procedures.EmployeeAddOrEditAsync(employee.Empid, employee.Empname,employee.EmpDesignation,employee.EmpSalary,employee.EmpGender,employee.EmpEmail,employee.EmpAge,employee.EmpSkills);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(int empId)
        {
            var result = await dbContext.Procedures.EmployeeDeleteByIDAsync(empId);
            return result;
        }

        public async Task<EmployeeViewByIDResult> DetailsEmployeeAsync(int empId)
        {
            var result = await dbContext.Procedures.EmployeeViewByIDAsync(empId);
            var employee = result.FirstOrDefault(e => e.EMPID == empId);
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int empId)
        {
            Employee employee=dbContext.Employees.Where(x => x.Empid== empId).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }
            return employee;
        }
        public async Task EditEmployeeAsync(Employee employee)
        {
            await dbContext.Procedures.EmployeeAddOrEditAsync(employee.Empid, employee.Empname, employee.EmpDesignation, employee.EmpSalary, employee.EmpGender, employee.EmpEmail, employee.EmpAge, employee.EmpSkills);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetDeletedEmployeeAsync()
        {
            List<Employee> emp = await dbContext.Employees.FromSqlRaw("EXEC GetAllDeletedEmployees").ToListAsync();
            return emp ?? new List<Employee>();
        }

        public async Task RestoreEmployeeAsync(EmployeeViewByIDResult emp)
        {
            await dbContext.Procedures.RestoreEmployeeAsync(emp.EMPID);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await dbContext.Skills.ToListAsync();
        }
        public async Task<List<GetEmployeeDetailsResult>> GetSkillswithemployee()
        {
            return await dbContext.Procedures.GetEmployeeDetailsAsync();
        }

        public async Task<int> AddEmpskills(int employeeId, int skillId)
        {
            return await dbContext.Procedures.AddEmployeeSkillAsync(employeeId, skillId);
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string employeeEmail)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.EmpEmail== employeeEmail);
        }

        public async Task<int> UpdateEmpskills(int employeeId, int skillIds, string action)
        {
               return await dbContext.Procedures.UpdateEmployeeSkillAsync(employeeId, skillIds, action);
        }

        public async Task<List<Skill>> GetEmployeeSkillByID(int Empid)
        {
            var skillsResult = await dbContext.Procedures.GetSkillsByEmployeeIdAsync(Empid);
            var skills = skillsResult.Select(result => new Skill
            { 
                SkillId = result.SkillId,
                SkillName = result.SkillName,
            }).ToList();

            return skills;
        }
        public async Task<int> RemoveSkillsForEmployeeAsync(int empId)
        {
            var result = await dbContext.Procedures.RemoveSkillsForEmployeeAsync(empId);
            return result;
        }

    }
}
