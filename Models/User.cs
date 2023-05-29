using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<CardUserRelation> CardUserRelations { get; set; } = new List<CardUserRelation>();
}
