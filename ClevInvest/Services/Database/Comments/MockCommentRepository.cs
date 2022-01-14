using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClevInvest.Models;
using Microsoft.EntityFrameworkCore;

namespace ClevInvest.Services.Database.Comments
{
    public class MockCommentRepository : ICommentRepository
    {
        private ApplicationContext _db;
        private List<Article> _commentsList;

        public MockCommentRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments.Include(u => u.User)
                .OrderBy(c => c.Date);
        }

        public async Task AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
        }
    }
}