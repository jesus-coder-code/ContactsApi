using ContactsApi.Context;
using ContactsApi.Interfaces;
using ContactsApi.Models;

namespace ContactsApi.Respositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<User> Post(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
