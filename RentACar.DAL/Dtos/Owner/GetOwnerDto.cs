using AppCore.Entity;

namespace RentACar.DAL.Dtos.Owner
{
    public class GetOwnerDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
