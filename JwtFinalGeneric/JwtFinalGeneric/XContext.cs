using JwtFinalGeneric.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtFinalGeneric
{
    public class XContext : DbContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
