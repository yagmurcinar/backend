﻿using UdemyProject.Models;

namespace UdemyProject.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

    }
}