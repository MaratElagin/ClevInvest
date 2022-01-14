using System.Collections.Generic;
using System.Threading.Tasks;
using ClevInvest.Models;

namespace ClevInvest.Services.Database.Comments
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        
        Task AddComment(Comment comment);
    }
}