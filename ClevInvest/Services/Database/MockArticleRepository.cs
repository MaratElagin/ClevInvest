using System;
using System.Collections.Generic;
using System.Linq;
using ClevInvest.Models;

namespace ClevInvest.Services.Database
{
    public class MockArticleRepository : IArticleRepository
    {
        private List<Article> _articlesList;

        public MockArticleRepository()
        {
            _articlesList = new List<Article>()
            {
                new Article
                {
                    Id = 0, Title = "Как составить личный финансовый план",
                    Date = new DateTime(2021,12,20), DescriptionFile = "fin_plan.html", UserId = 0,
                    PhotoPath = "fin_plan.jpg", Views = 0
                },
                new Article
                {
                    Id = 1, Title = "Брокерский счёт и ИИС. В чём разница и какой выбрать?",
                    Date = new DateTime(2021,12,21), DescriptionFile = "choice.html", UserId = 1,
                    PhotoPath = "choice.jpg", Views = 1
                },
                new Article
                {
                    Id = 2, Title = "Инвестционные термины, которые должен знать каждый инвестор",
                    Date = new DateTime(2021,12,22), DescriptionFile = "study.html", UserId = 2,
                    PhotoPath = "study.jpg", Views = 2
                },
                new Article
                {
                    Id = 3, Title = "Инвестиционные фонды ETF. Преимущества и недостатки",
                    Date = new DateTime(2021,12,23), DescriptionFile = "etf.html", UserId = 3,
                    PhotoPath = "etf.jpg", Views = 3
                }
            };
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articlesList;
        }

        public Article GetArticle(int id)
        {
            return _articlesList.FirstOrDefault(a => a.Id == id);
        }
    }
}