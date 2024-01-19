using BlazorApp1.Models;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages
{
    public partial class DeletedEmployee
    {
        private List<Employee>? Employees;
        private List<GetEmployeeDetailsResult>? _skills;
        Dictionary<int, string> employeeDetails = new Dictionary<int, string>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employees = await MyService.GetDeletedEmployeeAsync();
                foreach (var employee in Employees)
                {
                    _skills = await MyService.GetSkillswithemployee();
                    foreach (var skill in _skills)
                    {
                        var empskill = _skills
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

        private async Task RestoreEmployee(Employee employee)
        {
            await MyService.RestoreEmployeeAsync(employee);
            await JSRuntime.InvokeVoidAsync("alert", "Employee restored successfully!");
            NavigationManager.NavigateTo("/mypage");

        }
        private async Task BackToList()
        {
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
