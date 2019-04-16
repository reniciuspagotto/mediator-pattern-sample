using MediatorPatternExample.Domain.Customer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPatternExample.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<CustomerEntity> Customers { get; }

        public CustomerRepository()
        {
            Customers = new List<CustomerEntity>();
        }

        public async Task Save(CustomerEntity customer)
        {
            await Task.Run(() => Customers.Add(customer));
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await Task.FromResult(Customers);
        }

        public async Task Update(int id, CustomerEntity customer)
        {
            int index = Customers.FindIndex(m => m.Id == id);
            if (index >= 0)
                await Task.Run(() => Customers[index] = customer);
        }

        public async Task Delete(int id)
        {
            int index = Customers.FindIndex(m => m.Id == id);
            await Task.Run(() => Customers.RemoveAt(index));        
        }

        public async Task<CustomerEntity> GetById(int id)
        {
            var result = Customers.Where(p => p.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }
    }
}
