using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class MyPage
    {
        private List<Employee>? Employees;
        private List<GetEmployeeDetailsResult>? skills;
        Dictionary<int, string> employeeDetails=new Dictionary<int, string>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employees = await MyService.GetEmployeesAsync();
                foreach (var employee in Employees)
                {
                    skills = await MyService.GetSkillswithemployee();
                    foreach (var skill in skills)
                    {
                        var empskill = skills
                            .Where(skill => skill.EMPID == employee.Empid)
                            .Select(skill => skill.SkillName);
                        employeeDetails[employee.Empid] = string.Join(" ,", empskill);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employees: {ex.Message}");
            }
        }

        private void NavigateToInsertEmployee()
        {
            NavigationManager.NavigateTo("/insertemployee");
        }

        private void NavigateToDetailsEmployee(int empId)
        {
            NavigationManager.NavigateTo($"/detailsemployee/{empId}");
        }

        public void EditClick(int empId)
        {
            NavigationManager.NavigateTo($"/editemployee/{empId}");
        }

        private void NavigateToDeletedEmployee()
        {
            NavigationManager.NavigateTo("/deletedemployee");
        }
    }
}
