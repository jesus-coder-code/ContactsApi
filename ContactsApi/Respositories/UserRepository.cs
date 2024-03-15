using ContactsApi.Context;
using ContactsApi.Interfaces;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Respositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Post(User user)
        {
            //throw new NotImplementedException();
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
