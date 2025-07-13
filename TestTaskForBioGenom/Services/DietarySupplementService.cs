using Microsoft.EntityFrameworkCore;
using TestTaskForBioGenom.Database;
using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public class DietarySupplementService : IDietarySupplementService
    {
        private readonly BioGenomDbContext _db = new();

        public IEnumerable<DietarySupplement> GetAllDietarySupplements()
        {
            return [.. _db.DietarySupplements];
        }

        public DietarySupplement GetDietarySupplement(int id)
        {
            DietarySupplement? dietarySupplement = _db.DietarySupplements.FirstOrDefault(d => d.Id == id);
            ArgumentNullException.ThrowIfNull(dietarySupplement);
            return dietarySupplement;
        }

        public IEnumerable<DietarySupplement> GetDietarySupplementsForUserFromForm(int idForm)
        {
            ArgumentNullException.ThrowIfNull(_db.Forms.FirstOrDefault(f => f.Id == idForm));
            IEnumerable<int> vitamines = _db.VitaminesForms.Include(v => v.Vitamine)
                .Where(l => l.FormId == idForm && l.Vitamine.DailyIntake > l.Intake)
                .Select(l => l.VitamineId);
            IEnumerable<DietarySupplement> dietarySupplements =
                _db.DietarySupplementsVitamines.Include(d => d.DietarySupplement)
                .Where(v => vitamines.Contains(v.VitamineId)).Select(l => l.DietarySupplement);
            return dietarySupplements;
        }
    }
}
