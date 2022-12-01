using AppCore.Entity;

namespace RentACar.DAL.Dtos.Customer
{
    public class AddCustomerDto : IDto
    {
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
