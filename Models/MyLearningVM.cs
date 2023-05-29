using System;
using System.Collections.Generic;

namespace UdemyProject.Models;

public partial class MyLearningVM
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int UserId { get; set; }
    public  DateTime  CreatedDate { get; set; }
    public Card? Lesson { get; set; }
    public User? User { get; set; }
}

