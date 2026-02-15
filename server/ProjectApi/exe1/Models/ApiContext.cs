using Microsoft.EntityFrameworkCore;
using exe1.Models;

namespace exe1.data
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }        
        public DbSet<User> Users => Set<User>();
        public DbSet<Basket> Baskets => Set<Basket>();
        public DbSet<Donor> Donors => Set<Donor>();
        public DbSet<Prize> Prizes => Set<Prize>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
    }
}
