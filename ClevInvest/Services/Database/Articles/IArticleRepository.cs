using System.Collections.Generic;
using System.Threading.Tasks;
using ClevInvest.Models;

namespace ClevInvest.Services.Database.Articles
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();

        Article GetArticle(int id);
        
        Task FillDb();

        Task AddArticle(Article article);

        Task UpdateArticle(Article oldArticle, Article newArticle);

        Task DeleteArticle(Article article);
    }
}