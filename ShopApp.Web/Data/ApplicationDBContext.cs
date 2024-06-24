using Microsoft.EntityFrameworkCore;
using ShopApp.Web.Models;

namespace ShopApp.Web.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
