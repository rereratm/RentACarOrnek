using AppCore.Entity;
using RentACar.DAL.Dtos.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarService : IEntity
    {
        public Task<List<GetListCarDto>> GetCarList();
        public Task<GetCarDto> GetCarById(int id);
        public Task<int> AddCar(AddCarDto addCarDto);
        public Task<int> UpdateCar(int id, UpdateCarDto updateCarDto);
        public Task<int> DeleteCar(int id);
    }
}
