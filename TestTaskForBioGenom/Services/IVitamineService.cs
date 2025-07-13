using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public interface IVitamineService
    {
        IEnumerable<Vitamine> GetAllVitamines();
        Vitamine GetVitamine(int id);
        IEnumerable<VitaminesForm> GetVitaminesByUser(int id);
    }
}