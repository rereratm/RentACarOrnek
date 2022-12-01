using AppCore.Entity;

namespace RentACar.DAL.Dtos.CarCustomer
{
    public class AddCarCustomerDto : IDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
