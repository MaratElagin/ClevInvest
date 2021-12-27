using System.Threading.Tasks;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClevInvest.Services
{
    public class Middleware
    {
        private SessionKeyStorage _sessionKeyStorage;
        
        private readonly RequestDelegate next;

        public Middleware(RequestDelegate next, ApplicationContext applicationContext)
        {
            this.next = next;
            _sessionKeyStorage = new SessionKeyStorage(applicationContext);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("auth", out var sessionKey))
            {
                var user = _sessionKeyStorage.GetUserByKey(sessionKey ?? "");
                context.Items["User"] = user;
            }

            await next(context);
        }
    }
}