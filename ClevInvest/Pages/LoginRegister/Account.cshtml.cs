using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.LoginRegister
{
    public class Account : PageModel
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
            
        public void OnGet()
        {
            UserName = User.Identity.Name;
            
        }
    }
}