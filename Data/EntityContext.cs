using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {                
        }


        public DbSet<Message> Messages { get; set; }
        public DbSet<SmsOriginator> SmsOriginators { get; set; }
    }
}
