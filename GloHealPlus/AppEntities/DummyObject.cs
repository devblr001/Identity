using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntities
{
    public class DummyObject : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; } = DateTime.MinValue;

        //public virtual IEnumerable<Product> Products { get; set; }


        //public bool SpecialClient(Client clientobj)
        //{
        //    return IsActive && DateTime.Now.Year - clientobj.DOB.Year > 50;
        //}
    }
}
