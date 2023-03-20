using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Contract
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int PostalCode { get; set; }
        public Guid CountryId { get; set; }
    }


}