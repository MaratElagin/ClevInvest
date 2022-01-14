using System;

namespace ClevInvest.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public int? ArticleId { get; set; }
    }
}