using ClevInvest.Infrastructure;
using ClevInvest.Models;
using ClevInvest.Services.Database;
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

        [BindProperty] 
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = Generator.HashStringMD5(NewUser.Password1);
                //var user = new User {UserName = rm.UserName, Login = rm.Login, Password = hashedPassword};
                NewUser.Password1 = hashedPassword;
                _db.Users.Add(NewUser);
                _db.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}