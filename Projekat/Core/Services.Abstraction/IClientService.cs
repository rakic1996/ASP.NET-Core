using Projekat.Core.Contract;
using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Services.Abstraction
{
    public interface IClientService
    {
        List<ClientDto> GetAllClients();
        Client GetClient(Guid id);
        Client InsertClient(ClientDtoInsert client);
        void UpdateClient(Client client);
        void DeleteClient(Guid id);
    }
}