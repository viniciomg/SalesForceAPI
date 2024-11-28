using SalesForce.Domain.Dto;
using SalesForce.Domain.Entities;
using SalesForce.Domain.Interfaces.Repository;
using SalesForce.Domain.Interfaces.Services;

namespace SalesForce.Services.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IList<ClientResDto>> GetAllClients()
    {
        var mockData = new List<Client>
        {
            new Client { Id = 1, NameSocial = "Empresa A", CompanyId = 1 },
            new Client { Id = 2, NameSocial = "Empresa B", CompanyId = 1 },
            new Client { Id = 3, NameSocial = "Empresa C", CompanyId = 2 }
        }.AsQueryable();

        var ret = mockData;
        //var ret =await _clientRepository.GetAllAsync(x => x.CompanyId == 1);
        return ret.Select(x => new ClientResDto { Id = x.Id, NameSocial = x.NameSocial }).ToList();
    }
}
