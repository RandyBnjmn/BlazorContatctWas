using BlazorContactWas.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BlazorContactWas.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnecion)
        {
            _dbConnection = dbConnecion;
        }

        public async Task DeleteContact(int id)
        {
            var sql = @"DELETE FROM Contact 
                        WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });


        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELECT Id,
                               FirstName,
                               LastName,
                               Phone,
                               Addrress
                       FROM Contact";
            return await _dbConnection.QueryAsync<Contact>(sql);
        }

        public  async Task<Contact> GetDetails(int id)
        {
            var sql = @" SELECT Id,
                               FirstName,
                               LastName,
                               Phone,
                               Addrress
                       FROM Contact 
                        WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        public async Task<bool> InsertContact(Contact contact)
        {
            try
            {
                var sql = @"INSERT INTO Contact (FirstName, LastName, Phone, Address) VALUES(@FristName, @LastName, @Phone, @Address)";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.FirstName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address
                });

                return result > 0; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            try
            {
                var sql = @"UPDATE Contact 
                            SET FirstName = @FristName, 
                            LastName = @LastName,
                            Phone = @Phone,
                            Address =  @Address
                            WHERE Id = @Id";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.Id,
                    contact.FirstName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address
                });

                return result > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
