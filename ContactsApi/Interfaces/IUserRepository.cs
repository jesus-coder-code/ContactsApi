using ContactsApi.Models;

namespace ContactsApi.Interfaces
{
    public interface IUserRepository
    {
        //Task<List<User>> GetAll();
        //Task<User> GetById(int id);
        Task<User> Post(User user);
        Task<User> Update(int id, User user);

        //Task<User> Delete(int id);
    }
}
