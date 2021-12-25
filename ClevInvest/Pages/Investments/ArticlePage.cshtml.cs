using System.Threading.Tasks;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    public class ArticlePage : PageModel
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlePage(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article Article { get; set; }

        public IActionResult OnGet(int id)
        {
            Article = _articleRepository.GetArticle(id);
            if (Article == null) return RedirectToPage("/NotFound");
            return Page();
        }

        public async Task<string> ReadArticleDescription(string articleDescription)
        {
            var descriptionPath = $"Pages/Articles/{articleDescription}";
            string description = await System.IO.File.ReadAllTextAsync(descriptionPath);
            return description;
        }
    }
}