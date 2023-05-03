using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public Hotel HotelPackage { get; set; }
        public Ticket TicketPackage { get; set; }
        public DateTime DtRegisterPackage { get; set; }
        public double ValuePackage { get; set; }
        public Client ClientPackage { get; set; }
    }
}
