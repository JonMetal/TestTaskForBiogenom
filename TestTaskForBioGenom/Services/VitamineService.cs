using Microsoft.EntityFrameworkCore;
using TestTaskForBioGenom.Database;
using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public class VitamineService : IVitamineService
    {
        private readonly BioGenomDbContext _db = new();

        public IEnumerable<Vitamine> GetAllVitamines()
        {
            return [.. _db.Vitamines];
        }

        public Vitamine GetVitamine(int id)
        {
            Vitamine? vitamine = _db.Vitamines.FirstOrDefault(v => v.Id == id);
            ArgumentNullException.ThrowIfNull(vitamine);
            return vitamine;
        }

        public IEnumerable<VitaminesForm> GetVitaminesByUser(int id)
        {
            ArgumentNullException.ThrowIfNull(_db.Users.FirstOrDefault(l => l.Id == id));
            return [.. _db.VitaminesForms.Include(v => v.Vitamine).Include(f => f.Form)
                .Where(l => l.Form.UserId == id)];
        }
    }
}
