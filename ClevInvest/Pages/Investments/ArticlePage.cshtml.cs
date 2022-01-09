using System;
using System.Linq;
using System.Threading.Tasks;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    [Authorize]
    public class ArticlePage : PageModel
    {
        private readonly IArticleRepository _articleRepository;
        private ApplicationContext _db;

        public ArticlePage(ApplicationContext db, IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
            _db = db;
        }

        [BindProperty] public Article Article { get; set; }

        public IActionResult OnGet(int id)
        {
            Article = _db.Articles.FirstOrDefault(a => a.Id == id);
            if (Article == null) return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost(string description)
        {
            _db.Articles.FirstOrDefault(a => a.Id == Article.Id).Description = description;
            _db.SaveChanges();
            return OnGet(Article.Id);
        }
    }
}