using MediatR;
using SalesForce.Domain.Dto;
using SalesForce.Domain.Entities;
using SalesForce.Domain.Interfaces.Repository;
using SalesForce.Domain.Interfaces.Services;
using SalesForce.Services.Base;
using SalesForce.Services.Notification.Implementation;
using SalesForce.Services.Notification.Interface;
using SalesForce.Services.Notification.Model;

namespace SalesForce.Services.Services;

public class ClientService : BaseService<Client>, IClientService
{
    private readonly IClientRepository _clientRepository;
    
    public ClientService(INotify notify, INotificationHandler<Notifications> notification, IClientRepository clientRepository) : base(notify, notification)
    {
        _clientRepository = clientRepository;
        _notify = notify.Invoke();
    }

    public async Task<IList<ClientResDto>> GetAllClients()
    {
        var mockData = new List<Client>
        {
            new Client { Id = 1, NameSocial = "Empresa A", CompanyId = 1 },
            new Client { Id = 2, NameSocial = "Empresa B", CompanyId = 1 },
            new Client { Id = 3, NameSocial = "Empresa C", CompanyId = 2 }
        }.AsQueryable();

        if (mockData.Count() < 4)
        {
            _notify.NewNotification("Invalido", "quantidade invalidas");
            return default;
        }
        return mockData.Select(x => new ClientResDto { Id = x.Id, NameSocial = x.NameSocial }).ToList();
        //var ret =await _clientRepository.GetAllAsync(x => x.CompanyId == 1);
    }
}
