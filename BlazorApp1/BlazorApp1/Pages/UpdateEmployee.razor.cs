using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class UpdateEmployee
    {
        public int Id { get; set; }
        private List<Employee>? Employees;
        private List<GetEmployeeDetailsResult>? skills;
        Dictionary<int, string> employeeDetails = new Dictionary<int, string>();
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
        private async Task ConfirmUpdate(int id)
        {
            NavigationManager.NavigateTo($"/editemployee/{id}");
        }
    }
}
