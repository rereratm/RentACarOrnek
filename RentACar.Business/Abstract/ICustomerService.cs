using AppCore.Entity;
using RentACar.DAL.Dtos.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICustomerService : IEntity
    {
        public Task<List<GetListCustomerDto>> GetCustomerList();
        public Task<GetCustomerDto> GetCustomerById(int id);
        public Task<int> AddCustomer(AddCustomerDto addCustomerDto);
        public Task<int> UpdateCustomer(int id, UpdateCustomerDto updateCustomerDto);
        public Task<int> DeleteCustomer(int id);
        public bool AnyTCNumber(string tcNumber);
    }
}
