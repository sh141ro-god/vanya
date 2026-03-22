using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class Client
{
    public int ClientId { get; set; }

    [Display(Name = "Имя")]
    public string Name { get; set; } = null!;

    [Display(Name = "Номер телефона")]
    public string? Number { get; set; }

    [Display(Name = "Адрес")]
    public string? Address { get; set; }

    [Display(Name = "Почта")]
    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
