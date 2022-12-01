using AppCore.Entity;
using RentACar.DAL.Dtos.Owner;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IOwnerService : IEntity
    {
        public Task<List<GetListOwnerDto>> GetOwnerList();
        public Task<GetOwnerDto> GetOwnerById(int id);
        public Task<int> AddOwner(AddOwnerDto addOwnerDto);
        public Task<int> UpdateOwner(int id, UpdateOwnerDto updateOwnerDto);
        public Task<int> DeleteOwner(int id);
    }
}
