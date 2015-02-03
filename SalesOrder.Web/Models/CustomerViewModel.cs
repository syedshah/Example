using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SalesOrder.Entity;

namespace SalesOrder.Web.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Customer customer)
        {
            this.Id = customer.Id;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;

        }
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        public int Zip { get; set; }

        public int Gender { get; set; }

    }
}