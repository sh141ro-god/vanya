using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class Employee
{
    public int EmployeesId { get; set; }

    [Display(Name = "Имя")]
    public string Name { get; set; } = null!;

    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Display(Name = "Должность")]
    public int? Role { get; set; }

    [Display(Name = "Логин")]
    public string Login { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? RoleNavigation { get; set; }
}
