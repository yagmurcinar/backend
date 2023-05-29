using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class CardUserRelation
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public int UserId { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
