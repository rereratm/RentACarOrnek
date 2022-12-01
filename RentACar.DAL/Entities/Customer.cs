using AppCore.Entity;
using System.Collections.Generic;

namespace RentACar.DAL.Entities
{
    public class Customer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<CarCustomer> CarCustomers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
