using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekat.Core.Contract;
using Projekat.Core.Domain;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Domain.Exception;
using Projekat.Core.Services.Abstraction;

namespace Projekat.Core.Services
{
    public class ClientService : IClientService
    {
        private IRepository<Client> _repository;
        private ICountryRepository _repositoryCountry;

        public ClientService(IRepository<Client> repository, ICountryRepository countryRepository)
        {
            _repository = repository;
            _repositoryCountry = countryRepository;
        }

        public List<ClientDto> GetAllClients()
        {

            IEnumerable<Client> clients = _repository.GetAll();
            List<ClientDto> clientDtos = new List<ClientDto>();
            foreach (var client in clients)
            {

                ClientDto dto = new ClientDto();
                dto.Id = client.Id;
                dto.Name = client.Name;
                dto.Address = client.Address;
                dto.City = client.City;
                dto.PostalCode = client.PostalCode;
                if (client.country != null)
                {
                    dto.CountryId = client.country.Id;
                }
                clientDtos.Add(dto);

            }
            return clientDtos;
        }

        public Client GetClient(Guid id)
        {
            Client gotClient = _repository.Get(id);

            if (gotClient is null)
            {
                throw new ClientNotFoundException(id);
            }
            else
            {
                return gotClient;
            }
        }

        public Client InsertClient(ClientDtoInsert dto)
        {
            Country selectedCountry = _repositoryCountry.GetCountry(dto.CountryId);
            Client client = new Client(Guid.NewGuid(), dto.Name, dto.Address,
             dto.City, dto.PostalCode, selectedCountry);
            _repository.Create(client);
            _repository.SaveChanges();
            return client;
        }

        public void UpdateClient(Client client)
        {
            Client foundClient = GetClient(client.Id);

            if (foundClient is null)
            {
                throw new ClientNotFoundException(client.Id);
            }

            foundClient.Name = client.Name;
            foundClient.Address = client.Address;
            foundClient.City = client.City;
            foundClient.PostalCode = client.PostalCode;
            foundClient.country = client.country;
            _repository.Update(foundClient);
            _repository.SaveChanges();
        }

        public void DeleteClient(Guid id)
        {
            Client foundClient = GetClient(id);

            if (foundClient is null)
            {
                throw new ClientNotFoundException(id);
            }
            _repository.Remove(foundClient);
            _repository.SaveChanges();
        }
    }
}