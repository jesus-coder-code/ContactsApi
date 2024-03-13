using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Interfaces
{
    public interface IContactRepository
    {
        /*Task<Contact> Post(Contact contact);
        Task<Contact> Update(int id, Contact contact);
        Task Delete(int id);
        Task<Contact> GetById(int id);
        Task<Contact> Get();*/
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<Contact> Post(Contact contact);
        Task<Contact> Update(int id, Contact contact);

        Task<Contact> Delete(int id);

    }
}
