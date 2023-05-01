using System.ComponentModel.DataAnnotations;
using Models.DTO;
using Newtonsoft.Json;

namespace Models
{
    public class Address
    {
        public static readonly string GETALL = "select a.Id_Address, a.Street, a.Number,a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, ci.Id_City, ci.Description, ci.DtRegister_City FROM Address a JOIN City ci on a.Id_City_Address = ci.Id_City";
        public static readonly string INSERT = "insert into Address (Street, Number, Neighborhood, Cep, Complement, Id_City_Address, DtRegister_Address) values (@Street, @Number, @Neighborhood, @Cep, @Complement, @Id_City_Address, @DtRegister_Address); Select cast(scope_identity() as int)";
        public static readonly string DELETE = "delete from Address where Id_Address = @Id_Address";
        public static readonly string UPDATE = "update Address set Street = @Street, Number = @Number, Neighborhood = @Neighborhood,Cep = @Cep, Complement = @Complement, DtRegister_Address = @DtRegister_Address  where Id_Address = @Id_Address";

        [Key]
        public int Id_Address { get; set; }

        
        public string Street { get; set; }


        public int Number { get; set; }

        public string Neighborhood { get; set; }
        
        public string Cep { get; set; }

        public string Complement { get; set; }

        public City Id_City_Address { get; set; }

        public DateTime DtRegister_Address { get; set; }


        public Address(AddressDTO addressDTO)
        {
            this.Street = addressDTO.Logradouro;
            this.Number = addressDTO.Number;
            this.Neighborhood = addressDTO.Bairro;
            this.Cep = addressDTO.CEP;
            this.Complement = addressDTO.Complemento;
            this.Id_City_Address = new City { Description = addressDTO.City };
            this.DtRegister_Address = DateTime.Now;

        }

        public Address()
        {

        }
    }
}