using System.Collections.Generic;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    public class Articles : PageModel
    {
        private readonly IArticleRepository _db;

        public Articles(IArticleRepository db)
        {
            _db = db;
        }

        public IEnumerable<Article> ArticlesList { get; set; }

        public void OnGet()
        {
            ArticlesList = _db.GetAll();
        }
    }
}