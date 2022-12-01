using AppCore.Entity;
using System.Collections.Generic;

namespace RentACar.DAL.Entities
{
    public class Car : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string GasDieselElectric { get; set; }
        public int OwnerId { get; set; }
        public Owner OwnerFK { get; set; }
        public ICollection<CarCustomer> CarCustomers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
