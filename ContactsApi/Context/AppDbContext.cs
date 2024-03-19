using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) 
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(e => e.User)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }*/

    }
}
