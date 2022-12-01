using AppCore.Entity;

namespace RentACar.DAL.Dtos.Owner
{
    public class UpdateOwnerDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
