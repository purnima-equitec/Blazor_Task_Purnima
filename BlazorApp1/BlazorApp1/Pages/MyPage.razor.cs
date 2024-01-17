using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class MyPage
    {
        private List<Employee> Employees;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employees = await MyService.GetEmployeesAsync();
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

        private async Task DeleteEmployee(int empId)
        {
            try
            {
                int deletedRows = await MyService.DeleteEmployeeAsync(empId);
                if (deletedRows > 0)
                {
                    Employees = await MyService.GetEmployeesAsync();
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
