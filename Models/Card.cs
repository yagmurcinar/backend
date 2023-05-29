using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class Card
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? Point { get; set; }

    public string Instructor { get; set; } = null!;

    public string Image { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<CardUserRelation> CardUserRelations { get; set; } = new List<CardUserRelation>();

    public virtual Category Category { get; set; } = null!;
}
