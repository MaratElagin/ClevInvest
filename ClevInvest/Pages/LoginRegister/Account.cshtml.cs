using System.Linq;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.LoginRegister
{
    public class Account : PageModel
    {
        private ApplicationContext _db;

        public Account(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public string Login { get; set; }
        public User AuthorizedUser { get; set; }

        public void OnGet()
        {
            Login = User.Identity.Name;
            AuthorizedUser = _db.Users.FirstOrDefault(u => u.Login == Login);
        }
    }
}