using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class EditEmployee
    {
        Employee employee = new Employee();
        private List<Skill> _skills = new List<Skill>();
        private List<int> _selectedSkills = new List<int>();
        [Parameter]
        public int Id { get; set; }
        protected override async  Task OnInitializedAsync()
        {
            employee = await MyService.GetEmployeeByIdAsync(Id);
            _skills = await MyService.GetSkillsAsync();
            _selectedSkills = employee.Skills.Select(skill => skill.SkillId).ToList();
        }

        private async  Task EditEmployeeData()
        {
            await MyService.EditEmployeeAsync(employee);
            int employeeId = employee.Empid;
            foreach (int skillId in _selectedSkills)
            {
                try
                {
                    string actionType = _selectedSkills.Contains(skillId) ? "Add" : "Remove";
                    await MyService.UpdateEmpskills(employeeId, skillId, actionType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating skill {skillId} for employee {employeeId}: {ex.Message}");
                }
            }

            NavigationManager.NavigateTo("/mypage");
        }

        private void ToggleSkill(int skillId)
        {
            if (_selectedSkills.Contains(skillId))
            {
                _selectedSkills.Remove(skillId);
            }
            else
            {
                _selectedSkills.Add(skillId);
            }
            StateHasChanged();
        }

        private bool IsSkillSelected(int skillId)
        {
            return employee.Skills != null && employee.Skills.Any(s => s.SkillId == skillId);
        }
    }
}
