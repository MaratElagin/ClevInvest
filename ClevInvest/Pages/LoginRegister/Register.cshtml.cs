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
    public class Register : PageModel
    {
        private ApplicationContext _db;

        public Register(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }
        
        public string Error = "";

        [BindProperty] 
        public User NewUser { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Error = "";
                if(_db.Users.Any(u=> u.Login == NewUser.Login))
                {
                    Error = "Пользователь с таким логином уже зарегистрирован";
                    return Page();
                }
                var hashedPassword = Generator.HashStringMD5(NewUser.Password1);
                NewUser.Password1 = hashedPassword;
                _db.Users.Add(NewUser);
                await Authenticate(NewUser.Login, NewUser.UserName);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            return Page();
        }
        
        private async Task Authenticate(string login, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim("userName", userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}