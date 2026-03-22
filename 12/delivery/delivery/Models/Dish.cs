using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class Dish
{
    public int DishId { get; set; }

    [Display(Name = "Имя")]
    public string Name { get; set; } = null!;

    [Display(Name = "Ресторан")]
    public int Restaurant { get; set; }

    [Display(Name = "Описание")]
    public string? Description { get; set; }

    [Display(Name = "Категория блюда")]
    public int? DishCategory { get; set; }

    [Display(Name = "Цена")]
    public int Cost { get; set; }

    public virtual DishCategory? DishCategoryNavigation { get; set; }

    public virtual ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();

    public virtual Restaurant RestaurantNavigation { get; set; } = null!;
}
