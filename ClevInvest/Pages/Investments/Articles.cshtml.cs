using System;
using System.Collections.Generic;
using System.Linq;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    [Authorize]
    public class Articles : PageModel
    {
        private readonly IArticleRepository _db;
        
        public Articles(IArticleRepository db)
        {
            _db = db;
        }

        public IEnumerable<Article> ArticlesList { get; set; }
        [BindProperty]
        public string SearchText { get; set; }
        public void OnGet()
        {
            ArticlesList = _db.GetAll();
        }
        
        public void OnPost()
        {
            string _searchText = SearchText.ToLowerInvariant();
            ArticlesList = _db.GetAll().Where(a => a.Title.ToLowerInvariant().Contains(_searchText));
        }
    }
}