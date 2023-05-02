using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public Address Origin { get; set; }

        public Address Destiny { get; set; }

        public Client ClientTicket { get; set; }

        public DateTime DateTicket { get; set; }

        public decimal ValueTicket { get; set; }
    }
}
