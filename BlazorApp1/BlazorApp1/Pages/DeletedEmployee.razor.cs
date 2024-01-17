using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class DeletedEmployee
    {
        private List<Employee> Employees;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employees = await MyService.GetDeletedEmployeeAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employees: {ex.Message}");
            }
        }

        private async Task RestoreEmployee(Employee employee)
        {
            await MyService.RestoreEmployeeAsync(employee);
            
        }

        private async Task BackToList()
        {
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
