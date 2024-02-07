using SOA_BioscoopCasus.Domain;

namespace SOA_BioscoopCasus.Interfaces
{
    public interface IExportStrategy
    {
        void export(Order order);
    }
}
