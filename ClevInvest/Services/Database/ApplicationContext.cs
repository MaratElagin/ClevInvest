using ClevInvest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClevInvest.Services.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }
    }
}