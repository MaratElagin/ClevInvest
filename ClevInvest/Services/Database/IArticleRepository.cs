using System.Collections.Generic;
using ClevInvest.Models;

namespace ClevInvest.Services.Database
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();

        Article GetArticle(int id);
    }
}