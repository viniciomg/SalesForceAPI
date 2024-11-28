using SalesForce.Domain.Dto;

namespace SalesForce.Domain.Interfaces.Services;

public interface IClientService
{
    Task<IList<ClientResDto>> GetAllClients();
}
