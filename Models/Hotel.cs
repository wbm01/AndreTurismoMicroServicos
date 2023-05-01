using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hotel
    {
        public static readonly string GETALL = "select h.Id_Hotel, h.Name_Hotel, h.Hotel_Value, a.Id_Address, a.Street, a.Number, a.Neighborhood, a.Cep, a.Complement, ci.Id_City, ci.Description, h.DtRegister_Hotel FROM Hotel h JOIN Address a on h.Id_Address_Hotel = a.Id_Address join City ci on ci.Id_City = a.Id_City_Address";
        public static readonly string INSERT = "insert into Hotel (Name_Hotel, Id_Address_Hotel, DtRegister_Hotel, Hotel_Value) values (@Name_Hotel,@Id_Address_Hotel, @DtRegister_Hotel, @Hotel_Value); Select cast(scope_identity() as int)";
        public static readonly string DELETE = "delete from Hotel where Id_Hotel = @Id_Hotel";
        public static readonly string UPDATE = "update Hotel set Name_Hotel = @Name_Hotel, DtRegister_Hotel = @DtRegister_Hotel, Hotel_Value = @Hotel_Value, where Id_Hotel = @Id_Hotel";

        [Key]
        public int Id_Hotel { get; set; }

        public string Name_Hotel { get; set; }

        public Address Id_Address_Hotel { get; set; }

        public DateTime DtRegister_Hotel { get; set; }

        public decimal Hotel_Value { get; set; }
    }
}
