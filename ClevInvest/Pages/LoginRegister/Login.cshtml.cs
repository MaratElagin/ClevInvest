using System.Linq;
using ClevInvest.Infrastructure;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.LoginRegister
{
    public class Login : PageModel
    {
        private ApplicationContext _db;

        public Login(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        [BindProperty] public User RegisteredUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var password = Generator.HashStringMD5(RegisteredUser.Password1);
            var user = _db.Users.FirstOrDefault(u => u.Login == RegisteredUser.Login);
            if (user is null || user.Password1 != password)
                return RedirectToPage("/NotFound");
            HttpContext.Session.SetString("user", RegisteredUser.Login);
            return Redirect("/");
        }
    }
}