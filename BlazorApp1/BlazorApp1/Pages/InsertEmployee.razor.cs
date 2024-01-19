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
            await MyService.AddEmployeeAsync(employee);
            Employee addedEmployee = await MyService.GetEmployeeByEmailAsync(employee.EmpEmail);
            if (addedEmployee != null)
            {
                int employeeId = addedEmployee.Empid;
                foreach (int skillId in selectedSkills)
                {
                    try
                    {
                        await MyService.AddEmpskills(employeeId, skillId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding skill {skillId} for employee {employeeId}: {ex.Message}");
                    }
                }

                NavigationManager.NavigateTo("/mypage");
            }
            else
            {
                Console.WriteLine("Error: Employee not found after adding.");
            }
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
            StateHasChanged();
        }
    }
}