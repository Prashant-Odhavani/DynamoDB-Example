using Amazon.DynamoDBv2.DataModel;
using DynamoDBDemo.DTOs;

namespace DynamoDBDemo.Repositories;

public class CustomerRepository(IDynamoDBContext dynamoDBContext) : ICustomerRepository
{

    public async Task CreateOrUpdate(Customer customer)
    {
        await dynamoDBContext.SaveAsync(customer);
    }
   
    public async Task<Customer?> Get(string id)
    {
        return await dynamoDBContext.LoadAsync<Customer>(id, "Prashant");
    }

    public async Task<List<Customer>> GetAll()
    {
        var scanResult = dynamoDBContext.ScanAsync<Customer>(new List<ScanCondition>());
        var allCustomers = await scanResult.GetRemainingAsync();
        return allCustomers;
    }

    public async Task Delete(string id)
    {
        await dynamoDBContext.DeleteAsync<Customer>(id);
    }
}