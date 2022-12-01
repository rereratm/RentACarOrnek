using AppCore.Entity;
using RentACar.DAL.Dtos.CarCustomer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarCustomerService : IEntity
    {
        public Task<List<GetListCarCustomerDto>> GetCarCustomerList();
        public Task<GetCarCustomerDto> GetCarCustomerById(int id);
        public Task<int> AddCarCustomer(AddCarCustomerDto addCarCustomerDto);
        public Task<int> UpdateCarCustomer(int id, UpdateCarCustomerDto updateCarCustomerDto);
        public Task<int> DeleteCarCustomer(int id);
    }
}
