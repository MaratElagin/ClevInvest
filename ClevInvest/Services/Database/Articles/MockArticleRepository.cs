using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClevInvest.Models;

namespace ClevInvest.Services.Database.Articles
{
    public class MockArticleRepository : IArticleRepository
    {
        private ApplicationContext _db;
        private List<Article> _articlesList;

        public MockArticleRepository(ApplicationContext db)
        {
            _db = db;
            _articlesList = new()
            {
                new Article
                {
                    Id = 1, Title = "Как составить личный финансовый план",
                    Date = new DateTime(2021, 12, 20), UserId = 0,
                    Description = "Финансовый план очень важен!",
                    PhotoPath = "fin_plan.jpg", Views = 0
                },
                new Article
                {
                    Id = 2, Title = "Брокерский счёт и ИИС. В чём разница и какой выбрать?",
                    Date = new DateTime(2021, 12, 21), UserId = 1,
                    Description =
                        "Брокерский счет — счет, на котором учитываются все сделки, операции и активы клиента по договору на <br /><br />" +
                        "брокерское обслуживание, а сами операции совершаются по поручению клиента на бирже или на внебиржевом рынке." +
                        "ИИС — индивидуальный инвестиционный счет. Вид брокерского счета для долгосрочных инвестиций с льготным налоговым" +
                        "режимом. Главное ограничение — деньги со счета нельзя выводить три года. Если вывести деньги в этот период, то счет" +
                        "закроется, а налоговых вычетов не будет (а полученные ранее придется вернуть).",
                    PhotoPath = "choice.jpg", Views = 1
                },
                new Article
                {
                    Id = 3, Title = "Инвестиционные термины, которые должен знать каждый инвестор",
                    Date = new DateTime(2021, 12, 22), UserId = 2,
                    PhotoPath = "study.jpg", Views = 2
                },
                new Article
                {
                    Id = 4, Title = "Инвестиционные фонды ETF. Преимущества и недостатки",
                    Date = new DateTime(2021, 12, 23), UserId = 3,
                    PhotoPath = "etf.jpg", Views = 3
                },
                new Article
                {
                    Id = 5, Title = "Инвестиционные фонды ПИФ. Преимущества и недостатки",
                    Date = new DateTime(2021, 12, 23), UserId = 4,
                    PhotoPath = "etf.jpg", Views = 3
                },
                new Article
                {
                    Id = 6, Title = "Преимущества и недостатки",
                    Date = new DateTime(2021, 12, 23), UserId = 4,
                    Views = 3, PhotoPath = "Vavilon.jpg"
                },
                new Article
                {
                    Id = 7, Title = "Test22. Преимущества и недостатки",
                    Date = new DateTime(2021, 12, 23), UserId = 4,
                    Views = 3
                },
                new Article
                {
                    Id = 8, Title = "Инвестиционные термины, которые должен знать каждый инвестор",
                    Date = new DateTime(2021, 12, 22), UserId = 2,
                    PhotoPath = "study.jpg", Views = 2
                },
            };
        }

        public IEnumerable<Article> GetAll()
        {
            if (!_db.Articles.Any()) FillDb();
            return _db.Articles.OrderBy(a=>a.Id);
        }

        public Article GetArticle(int id)
        {
            return _db.Articles.FirstOrDefault(a => a.Id == id);
        }

        public async Task FillDb()
        {
            foreach (var article in _articlesList)
                if (!_db.Articles.Contains(article))
                    await AddArticle(article);
        }

        public async Task AddArticle(Article article)
        {
            _db.Articles.Add(article);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateArticle(Article oldArticle, Article newArticle)
        {
            newArticle.Id = oldArticle.Id;
            await DeleteArticle(oldArticle);
            _db.Articles.Add(newArticle);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteArticle(Article article)
        {
            _db.Articles.Remove(article);
            await _db.SaveChangesAsync();
        }
    }
}