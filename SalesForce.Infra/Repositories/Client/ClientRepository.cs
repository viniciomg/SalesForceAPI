using SalesForce.Domain.Entities;
using SalesForce.Domain.Interfaces.Repository;
using SalesForce.Infra.Base;
using SalesForce.Infra.Context;

namespace SalesForce.Infra.Repositories;

public class ClientRepository : EFCoreRepositoryBase<SalesForceContext, Client>, IClientRepository
{
    public ClientRepository(SalesForceContext dbContextProvider) : base(dbContextProvider)
    {
    }
}
