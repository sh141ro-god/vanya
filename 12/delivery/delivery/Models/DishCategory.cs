using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class DishCategory
{
    public int DishCategoryId { get; set; }

    [Display(Name = "Имя")]
    public string Name { get; set; } = null!;

    [Display(Name = "Описание")]
    public string? Description { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
