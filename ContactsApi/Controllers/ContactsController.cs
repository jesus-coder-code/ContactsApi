using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsApi.Models;
using ContactsApi.Interfaces;
using System.Data.Entity;
using ContactsApi.Respositories;
using Microsoft.EntityFrameworkCore;
using ContactsApi.Context;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IContactRepository _contactRepository;
        public ContactsController(AppDbContext context,IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _contactRepository.GetAll();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepository.GetById(id);

            if (contact == null)
            {
                return NotFound(new {message = "contact not found"});
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            try
            {
                await _contactRepository.Update(id, contact);
                return Ok(new {message = "contact was updated"});
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound(new {message = "contact doesn't exist"});
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            await _contactRepository.Post(contact);
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                var contact = await _contactRepository.Delete(id);
                if (contact == null)
                {
                    return NotFound(new { message = "contact not found" });
                }

                return Ok(new { message = "contact was deleted" });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

    }
}
