using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public interface IDietarySupplementService
    {
        IEnumerable<DietarySupplement> GetAllDietarySupplements();
        DietarySupplement GetDietarySupplement(int id);
        IEnumerable<DietarySupplement> GetDietarySupplementsForUserFromForm(int idForm);
    }
}