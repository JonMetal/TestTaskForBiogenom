using Microsoft.AspNetCore.Mvc;
using TestTaskForBioGenom.Database.Entities;
using TestTaskForBioGenom.Services;

namespace TestTaskForBioGenom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DietarySupplementsController(IDietarySupplementService dietarySupplementService) : Controller
    {
        private readonly IDietarySupplementService _dietarySupplementService = dietarySupplementService;

        [HttpGet("")]
        public IEnumerable<DietarySupplement> GetDietarySupplements()
        {
            return _dietarySupplementService.GetAllDietarySupplements();
        }

        [HttpGet("{id}")]
        public ActionResult<DietarySupplement> GetDietarySupplement(int id)
        {
            try
            {
                return _dietarySupplementService.GetDietarySupplement(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FromForm/{id}")]
        public ActionResult<IEnumerable<DietarySupplement>> GetDietarySupplementFromForm(int id)
        {
            try
            {
                return Ok(_dietarySupplementService.GetDietarySupplementsForUserFromForm(id));
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
