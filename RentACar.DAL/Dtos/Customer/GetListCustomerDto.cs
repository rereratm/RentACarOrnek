using AppCore.Entity;

namespace RentACar.DAL.Dtos.Customer
{
    public class GetListCustomerDto : IDto
    {
        public int Id { get; set; }
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
