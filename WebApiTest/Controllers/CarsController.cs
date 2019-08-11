using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Data;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {

        #region Variables Privadas

        private readonly ICarsRepository _repo;


        #endregion


        #region Constructores

        public CarsController(ICarsRepository repository)
        {
            _repo = repository;
        }

        #endregion

        #region Metodos GET

        // GET: api/Cars
        [HttpGet("GetCarByUserID")]
        
        public async Task<IActionResult> GetCarByLoggedUser(int UserID)
        {
            var car = await _repo.GetCarByUser(UserID);

            if (car == null)
                return NotFound("No se encontro carro para ese ID");

            return Ok(car);
        }

        #endregion
    }
}
