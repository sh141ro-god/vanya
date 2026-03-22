using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace delivery.Models;

public partial class Order
{
    public int OrderId { get; set; }

    [Display(Name = "Сотрудник")]
    public int? Employee { get; set; }

    [Display(Name = "Клиент")]
    public int Client { get; set; }

    [Display(Name = "Статус заказа")]
    public int Status { get; set; }

    [Display(Name = "Адрес")]
    public string Address { get; set; } = null!;

    [Display(Name = "Цена")]
    public int? Cost { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Employee? EmployeeNavigation { get; set; }

    public virtual ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();

    public virtual OrderStatus StatusNavigation { get; set; } = null!;
}
