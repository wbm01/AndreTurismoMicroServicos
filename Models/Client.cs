using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string NameClient { get; set; }

        public string Phone { get; set; }

        public Address AddressClient { get; set; }

        public DateTime DtRegisterClient { get; set; }
    }
}
