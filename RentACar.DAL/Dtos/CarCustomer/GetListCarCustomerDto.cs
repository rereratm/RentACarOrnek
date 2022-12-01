using AppCore.Entity;

namespace RentACar.DAL.Dtos.CarCustomer
{
    public class GetListCarCustomerDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public string GasDieselElectric { get; set; }
        public int CustomerId { get; set; }
        public string CustomerTcNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
