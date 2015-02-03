namespace SalesOrder.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        [StringLength(2)]
        public string Abbreviation { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
