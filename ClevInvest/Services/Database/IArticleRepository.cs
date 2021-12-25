using System.Collections.Generic;
using ClevInvest.Models;

namespace ClevInvest.Services.Database
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAllArticles();

        Article GetArticle(int id);
    }
}