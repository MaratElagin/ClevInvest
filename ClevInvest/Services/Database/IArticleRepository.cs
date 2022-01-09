using System.Collections.Generic;
using System.Threading.Tasks;
using ClevInvest.Models;

namespace ClevInvest.Services.Database
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();

        Article GetArticle(int id);

        Task FillDB();

        Task AddArticle(Article article);

        Task UpdateArticle(Article oldArticle, Article newArticle);

        Task DeleteArticle(Article article);
    }
}