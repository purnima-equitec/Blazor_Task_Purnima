﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;

public partial class Employee
{
    public int Empid { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    [StringLength(100, ErrorMessage = "Employee name must be at most 100 characters.")]
    public string Empname { get; set; }

    [Required(ErrorMessage = "Employee Designation is required.")]
    public string EmpDesignation { get; set; }


    [Required(ErrorMessage = "Employee Salary is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Employee salary must be a non-negative value.")]
    public int? EmpSalary { get; set; }

    public bool? IsDeleted { get; set; }

    [Required(ErrorMessage = "Employee gender is required.")]
    public string EmpGender { get; set; }

    [Required(ErrorMessage = "Employee email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string EmpEmail { get; set; }

    [Required(ErrorMessage = "Employee Age is required.")]
    [Range(18, 60, ErrorMessage = "Employee age must be between 18 and 60.")]
    public int? EmpAge { get; set; }

    public string EmpSkills { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}