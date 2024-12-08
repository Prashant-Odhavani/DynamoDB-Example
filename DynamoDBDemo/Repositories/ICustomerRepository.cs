using DynamoDBDemo.DTOs;

namespace DynamoDBDemo.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateOrUpdate(Customer customer);
        Task<Customer?> Get(string id);
        Task<List<Customer>> GetAll();
        Task Delete(string id);
    }
}
