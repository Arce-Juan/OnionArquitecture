using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Client : AuditableBaseEntity
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                this._age = new DateTime(DateTime.Now.Subtract(this.DateBirth).Ticks).Year - 1;

                return this._age;
            }
        }
    }
}
