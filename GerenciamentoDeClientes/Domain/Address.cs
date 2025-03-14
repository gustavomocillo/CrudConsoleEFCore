using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsManagement.Domain
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
