// InsertEmployee.razor.cs

using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class InsertEmployee
    {
        private Employee employee = new Employee();
        private List<Skill> skills = new List<Skill>();
        private List<int> selectedSkills = new List<int>();
        protected override async Task OnInitializedAsync()
        {
            skills = await MyService.GetSkillsAsync();
        }
        private async Task AddEmployee()
        {
            employee.Skills = skills.Where(skill => selectedSkills.Contains(skill.SkillId)).ToList();
            employee.EmpSkills = string.Join(",", employee.Skills.Select(skill => skill.SkillId));
            await MyService.AddEmployeeAsync(employee);
            NavigationManager.NavigateTo("/mypage");
        }

        private void ToggleSkill(int skillId)
        {
            if (selectedSkills.Contains(skillId))
            {
                selectedSkills.Remove(skillId);
            }
            else
            {
                selectedSkills.Add(skillId);
            }
        }
    }
}
