using Microsoft.AspNetCore.Mvc;
using TestTaskForBioGenom.Database.Entities;
using TestTaskForBioGenom.Services;

namespace TestTaskForBioGenom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormsController(IFormService formService) : Controller
    {
        private readonly IFormService formService = formService;

        [HttpGet("{id}")]
        public ActionResult<Form> GetForm(int id)
        {
            try
            {
                return Ok(formService.GetForm(id));
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

        [HttpGet("ByUser/{id}")]
        public ActionResult<Form> GetFormByUser(int id)
        {
            try
            {
                return Ok(formService.GetFormByUser(id));
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