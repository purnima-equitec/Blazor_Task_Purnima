﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BlazorApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public partial interface IDapperDBContextProcedures
    {
        Task<int> AddEmployeeSkillAsync(int? EmployeeId, int? SkillId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeAddOrEditAsync(int? EMPID, string EMPNAME, string EMP_DESIGNATION, int? EMP_SALARY, string EMP_GENDER, string EMP_EMAIL, int? EMP_AGE, string EMP_SKILLS, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeDeleteByIDAsync(int? EMPID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeViewAllResult>> EmployeeViewAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeViewByIDResult>> EmployeeViewByIDAsync(int? EMPID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllDeletedEmployeesResult>> GetAllDeletedEmployeesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetEmployeeDetailsResult>> GetEmployeeDetailsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetSkillsByEmployeeIdResult>> GetSkillsByEmployeeIdAsync(int? EmployeeId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> RemoveSkillsForEmployeeAsync(int? EmployeeId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> RestoreEmployeeAsync(int? EMPID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEmployeeSkillAsync(int? EmployeeId, int? SkillId, string Action, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEmployeeSkillsAsync(int? EmployeeId, string SkillIds, string ActionType, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
