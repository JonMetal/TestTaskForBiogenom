using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public interface IFormService
    {
        Form GetForm(int id);
        Form GetFormByUser(int id);
    }
}