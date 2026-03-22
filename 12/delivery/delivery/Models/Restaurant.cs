using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    [Display(Name = "Имя")]
    public string Name { get; set; } = null!;

    [Display(Name = "Номер телефона")]
    public string? Numder { get; set; }

    [Display(Name = "Адрес")]
    public string? Address { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
