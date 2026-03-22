using System;
using System.Collections.Generic;

namespace delivery.Models;

public partial class OrderPart
{
    public int DishId { get; set; }

    public int OrderId { get; set; }

    public int Count { get; set; }

    public int Cost { get; set; }

    public virtual Dish Dish { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
