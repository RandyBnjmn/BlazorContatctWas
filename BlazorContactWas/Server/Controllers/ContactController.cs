using BlazorContactWas.Repository;
using BlazorContactWas.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorContactWas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetById(int id)
        {
           
            return await _repository.GetDetails(id);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");

            if (string.IsNullOrEmpty(contact.Phone))
                ModelState.AddModelError("Phone", "Phone can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.InsertContact(contact);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");

            if (string.IsNullOrEmpty(contact.Phone))
                ModelState.AddModelError("Phone", "Phone can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.UpdateContact(contact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            await _repository.DeleteContact(id);
            return NoContent();
        }
    }
}
