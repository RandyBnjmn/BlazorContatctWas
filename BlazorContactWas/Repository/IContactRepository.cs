using BlazorContactWas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactWas.Repository
{
    public interface IContactRepository
    {
        Task<bool> InsertContact(Contact contact);
        Task<bool> UpdateContact(Contact contact);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task DeleteContact(int id);
    }
}
