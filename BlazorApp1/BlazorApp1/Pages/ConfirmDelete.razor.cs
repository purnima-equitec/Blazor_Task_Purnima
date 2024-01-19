using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace BlazorApp1.Pages
{
    public partial class ConfirmDelete
    {
        [Parameter]
        public int Id { get; set; }
        private EmployeeViewByIDResult? Employee { get; set; }
        private List<EmployeeViewByIDResult> user = new List<EmployeeViewByIDResult>();//
        private EmployeeViewByIDResult newUser = new EmployeeViewByIDResult();//
        private List<Skill> skills = new List<Skill>();//
        private string? skillname;
        private List<Employee>? Employees;

        protected override async Task OnInitializedAsync()
        {
            Employee = await MyService.DetailsEmployeeAsync(Id);
            skills = await MyService.GetEmployeeSkillByID(Id);//
            if (skills != null && skills.Any())
            {
                foreach (var skill in skills)
                {
                    skillname = skill.SkillName + ", " + skillname;
                }
                skillname = skillname.Substring(0, skillname.Length - 2);
            }
            else
            {
                skillname = "No skills available";
            }

            foreach (var item in user)
            {
                newUser = item;
            }
        }

        private async Task PerformDeleteEmployee(int empId)
        {
            try
            {
                int deletedRows = await MyService.DeleteEmployeeAsync(empId);
                if (deletedRows > 0)
                {
                    Employees = await MyService.GetEmployeesAsync();
                    await JSRuntime.InvokeVoidAsync("alert", "Employee deleted successfully!");
                    NavigationManager.NavigateTo("/deleteemployee");
                }
                else
                {
                    Console.WriteLine("Employee not found or unable to delete.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
            }
        }

        private async Task BackToList()
        {
            NavigationManager.NavigateTo("/deleteemployee");
        }
    }
}
