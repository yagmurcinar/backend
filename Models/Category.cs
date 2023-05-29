using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TopId { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<Category> InverseTop { get; set; } = new List<Category>();

    public virtual Category? Top { get; set; }
}
