using BlazorContactWas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorContactWas.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contact/{id}");
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>("api/contact/");
        }

        public async Task<Contact> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>("api/contact/");
        }

        public async Task InsertContact(Contact contact)
        {
            await _httpClient.PostAsJsonAsync("api/contact/", contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _httpClient.PutAsJsonAsync($"api/contact/{contact.Id}", contact);
        }
    }
}
