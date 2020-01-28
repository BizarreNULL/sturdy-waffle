using Microsoft.EntityFrameworkCore;

using Sturdy.Waffle.Shared.Models;

namespace Sturdy.Waffle.Console
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Paste> Pastes { get; set; }
        
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}