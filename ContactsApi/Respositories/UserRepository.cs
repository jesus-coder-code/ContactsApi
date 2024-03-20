using ContactsApi.Context;
using ContactsApi.Interfaces;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using ContactsApi.Infrastructure.Hash;

namespace ContactsApi.Respositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            //return await _context.Users.ToListAsync();
            return await _context.Users.Include(u => u.Contacts).ToListAsync();
        }

        public async Task<List<Contact>> GetByUserId(int userId)
        {
            var contacts = await _context.Contacts.Where(c => c.UserId == userId).ToListAsync(); return contacts;
        }

        public async Task<User> Post(User user)
        {
            string hashedPassword  = Hasher.HashPassword(user.Password);
            user.Password = hashedPassword;
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(int id, User user)
        {
            //throw new NotImplementedException();
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
