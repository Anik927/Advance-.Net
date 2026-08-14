using System;
using System.Collections.Generic;

namespace WebApplication2.Data.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }
}
