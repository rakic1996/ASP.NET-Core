namespace Projekat.Core.Domain.Entities
{
    
    public class Client
    {

        public Guid Id { get; set; } 
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int PostalCode { get; set; }
        public Country country { get; set; }

        public Client()
        {
        }

        
        public Client(Guid id, string name, string address, string city, int postalCode, Country country)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            this.country = country;

        }

        public override string ToString()
        {
            return "Name " + Name + "Address " + Address + "City " + City + "PostalCode " + PostalCode + "Country " + country;
        }
    }
}
