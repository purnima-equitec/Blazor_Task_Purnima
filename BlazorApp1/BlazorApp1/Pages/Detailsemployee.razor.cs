 using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class Detailsemployee
    {
        [Parameter] 
        public int Id { get; set; }
        private EmployeeViewByIDResult? Employee { get; set; }
        private List<EmployeeViewByIDResult> user = new List<EmployeeViewByIDResult>();
        private EmployeeViewByIDResult newUser = new EmployeeViewByIDResult();
        private List<Skill> skills = new List<Skill>();
        private string? skillname;

        protected override async Task OnInitializedAsync()  
        {
            Employee = await MyService.DetailsEmployeeAsync(Id);
            skills = await MyService.GetEmployeeSkillByID(Id);
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

        private async Task BackToList()
        {
            NavigationManager.NavigateTo("/mypage");
        }
    }
}
