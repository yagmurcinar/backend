using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class Basket
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int UserId { get; set; }
    public  DateTime  CreatedDate { get; set; }

}

