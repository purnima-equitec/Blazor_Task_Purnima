using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class EditEmployee
    {
        Employee employee = new Employee();
        [Parameter]
        public int Id { get; set; }
        protected override async  Task OnInitializedAsync()
        {
            employee = await MyService.GetEmployeeByIdAsync(Id);
        }

        private async  Task EditEmployeeData()
        {
            await MyService.EditEmployeeAsync(employee);
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
