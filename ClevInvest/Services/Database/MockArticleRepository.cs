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
                    Date = new DateTime(2021,12,20), UserId = 0,
                    Description = "Финансовый план очень важен!",
                    PhotoPath = "fin_plan.jpg", Views = 0
                },
                new Article
                {
                    Id = 1, Title = "Брокерский счёт и ИИС. В чём разница и какой выбрать?",
                    Date = new DateTime(2021,12,21), UserId = 1,
                    Description = "Брокерский счет — счет, на котором учитываются все сделки, операции и активы клиента по договору на <br /><br />" +
                                  "брокерское обслуживание, а сами операции совершаются по поручению клиента на бирже или на внебиржевом рынке." +
                                  "ИИС — индивидуальный инвестиционный счет. Вид брокерского счета для долгосрочных инвестиций с льготным налоговым" +
                                  "режимом. Главное ограничение — деньги со счета нельзя выводить три года. Если вывести деньги в этот период, то счет" +
                                  "закроется, а налоговых вычетов не будет (а полученные ранее придется вернуть).",
                    PhotoPath = "choice.jpg", Views = 1
                },
                new Article
                {
                    Id = 2, Title = "Инвестционные термины, которые должен знать каждый инвестор",
                    Date = new DateTime(2021,12,22), UserId = 2,
                    PhotoPath = "study.jpg", Views = 2
                },
                new Article
                {
                    Id = 3, Title = "Инвестиционные фонды ETF. Преимущества и недостатки",
                    Date = new DateTime(2021,12,23), UserId = 3,
                    PhotoPath = "etf.jpg", Views = 3
                }
            };
        }

        public IEnumerable<Article> GetAll()
        {
            return _articlesList;
        }

        public Article GetArticle(int id)
        {
            return _articlesList.FirstOrDefault(a => a.Id == id);
        }
    }
}