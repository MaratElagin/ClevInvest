using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ClevInvest.Controllers
{
    [Produces("application/json")]
    [Route("api/session")]
    public class Session : Controller
    {
        public Session()
        {
        }
        
        [HttpDelete]
        public async Task<object> Delete()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Json(new {result = "ok", message = ""});
            } 
            catch(Exception ex)
            {
                return Json(new {result = "error", message = "Ошибка"});
            }
        }
    }
}