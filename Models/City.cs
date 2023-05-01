using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City
    {
        public static readonly string GETALL = "select c.Id_City, c.Description, c.DtRegister_City FROM City c";
        public static readonly string GETID = "select c.Id_City, c.Description, c.DtRegister_City FROM City c WHERE Id_City = @Id_City";
        public static readonly string INSERT = "insert into City(Description, DtRegister_City) values (@Description, @DtRegister_City); Select cast(scope_identity() as int)";
        public static readonly string DELETE = "delete from City where Id_City = @Id_City";
        public static readonly string UPDATE = "update City set Description = @Description, DtRegister_City = @DtRegister_City where Id_City = @Id_City";

        [Key]
        public int Id_City { get; set; }

        public string Description { get; set; }

        public DateTime DtRegister_City { get; set; }
    }
}
