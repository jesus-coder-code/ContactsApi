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
    }
}
