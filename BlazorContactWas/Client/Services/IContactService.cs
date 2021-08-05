using BlazorContactWas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorContactWas.Client.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task InsertContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);

    }
}
 