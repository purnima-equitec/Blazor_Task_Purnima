using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class Detailsemployee
    {
        [Parameter]
        public int Id { get; set; }
        private EmployeeViewByIDResult? Employee { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await MyService.DetailsEmployeeAsync(Id);
        }

        private async Task BackToList()
        {
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
