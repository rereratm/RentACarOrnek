using AppCore.Entity;

namespace RentACar.DAL.Dtos.Customer
{
    public class UpdateCustomerDto : IDto
    {
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
