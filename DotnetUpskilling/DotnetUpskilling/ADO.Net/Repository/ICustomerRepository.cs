using DotnetUpskilling.ADO.Net.Entity;

namespace DotnetUpskilling.ADO.Net.Repository;

public interface ICustomerRepository
{
    void GeneratedTable();
    void Save(Customer customer);
    Customer? FindById(int customerId);
    List<Customer> FindAll();
    void Update(Customer customer);
    void DeleteById(int customerId);
}