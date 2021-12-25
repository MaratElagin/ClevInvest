﻿using System;

namespace ClevInvest.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string DescriptionFile { get; set; }
        public int UserId { get; set; }
        public  string PhotoPath { get; set; }
        public int Views { get; set; }
    }
}