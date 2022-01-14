using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClevInvest.Infrastructure;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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


        public string Error = "";

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public RegisteredUser RegisteredUser { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Error = "";
                var password = Generator.HashStringMD5(RegisteredUser.Password);
                var user = _db.Users.FirstOrDefault(u => u.Login == RegisteredUser.Login);
                if (user is null || user.Password1 != password)
                {
                    Error = "Неверный логин или пароль";
                    return Page();
                }

                await Authenticate(user.Login, user.UserName, user.Role);
                return Redirect("/");
            }

            return Page();
        }

        private async Task Authenticate(string login, string userName, string role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim("role", role ?? "user"),
                new Claim("userName", userName),
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}