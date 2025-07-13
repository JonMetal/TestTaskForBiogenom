using Microsoft.AspNetCore.Mvc;
using TestTaskForBioGenom.Database.Entities;
using TestTaskForBioGenom.Services;

namespace TestTaskForBioGenom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VitaminesController(IVitamineService vitamineService) : Controller
    {
        private readonly IVitamineService _vitamineService = vitamineService;

        [HttpGet("")]
        public IEnumerable<Vitamine> GetVitamines()
        {
            return _vitamineService.GetAllVitamines();
        }

        [HttpGet("{id}")]
        public ActionResult<Vitamine> GetVitamine(int id)
        {
            try
            {
                return Ok(_vitamineService.GetVitamine(id));
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
        public ActionResult<IEnumerable<VitaminesForm>> GetVitaminesByUser(int id)
        {
            try
            {
                return Ok(_vitamineService.GetVitaminesByUser(id));
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
