// InsertEmployee.razor.cs

using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class InsertEmployee
    {
        private Employee employee = new Employee();

        private async Task AddEmployee()
        {
            await MyService.AddEmployeeAsync(employee);
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
