
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Core.Domain.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set;}

        public List<Client> Clients { get; set; } 

        public Country()
        {

        }

        public Country(Guid id, string name, List<Client> clients)
        {
            Id = id;
            Name = name;
            Clients = Clients;
        }

        public Country(Guid guid, string name)
        {
            Name = name;
        }
    }
}