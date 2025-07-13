using TestTaskForBioGenom.Database;
using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Services
{
    public class FormService : IFormService
    {
        private readonly BioGenomDbContext _db = new();

        public Form GetForm(int id)
        {
            Form? form = _db.Forms.FirstOrDefault(f => f.Id == id);
            ArgumentNullException.ThrowIfNull(form);
            return form;
        }

        public Form GetFormByUser(int id)
        {
            Form? form = _db.Forms.FirstOrDefault(f => f.UserId == id);
            ArgumentNullException.ThrowIfNull(form);
            return form;
        }
    }
}
