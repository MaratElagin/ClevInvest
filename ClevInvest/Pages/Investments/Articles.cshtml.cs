using System;
using System.Collections.Generic;
using System.Linq;
using ClevInvest.Models;
using ClevInvest.Services.Database.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    [Authorize]
    public class Articles : PageModel
    {
        private readonly IArticleRepository _articleRepository;

        public Articles(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> ArticlesList { get; set; }
        [BindProperty] public string SearchText { get; set; }
        [BindProperty] public bool IsWithDescription { get; set; }

        public void OnGet()
        {
            ArticlesList = _articleRepository.GetAll();
        }

        public void OnPost()
        {
            string searchText = SearchText?.ToLowerInvariant();
            if (searchText == null)
                ArticlesList = _articleRepository.GetAll();
            else
            {
                if (IsWithDescription)
                {
                    List<Article> tmpList = new();
                    foreach (var article in _articleRepository.GetAll())
                    {
                        if (article.Description is not null &&
                            article.Description.ToLowerInvariant().Contains(searchText)
                            || article.Title.ToLowerInvariant().Contains(searchText))
                            tmpList.Add(article);
                    }

                    ArticlesList = tmpList;
                }

                else
                    ArticlesList = _articleRepository.GetAll().Where(a => a.Title.ToLowerInvariant().Contains(searchText));
            }
        }
    }
}