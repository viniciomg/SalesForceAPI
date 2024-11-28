namespace SalesForce.Domain.Entities;
public class Client
{
    public long Id { get; set; }
    public string NameSocial { get; set; }
    public int CompanyId { get; set; }
    public Object Address { get; set; }
}
