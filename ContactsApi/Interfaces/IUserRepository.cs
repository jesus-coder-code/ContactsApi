using ContactsApi.Models;

namespace ContactsApi.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<List<Contact>> GetByUserId(int userId);
        Task<User> Post(User user);
        Task<User> Update(int id, User user);

        //Task<User> Delete(int id);
    }
}
