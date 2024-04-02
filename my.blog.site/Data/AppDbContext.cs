using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using my.blog.site.Models;

namespace my.blog.site.Data
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
    }
}
