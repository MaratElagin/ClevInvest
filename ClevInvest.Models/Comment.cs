namespace ClevInvest.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int? ArticleId { get; set; }
    }
}