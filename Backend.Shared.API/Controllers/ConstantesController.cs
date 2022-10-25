using Backend.Shared.Entities.Interface.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{

    [ApiController, Route("api/v1/[controller]")]
    public class ConstantesController : ControllerBase
    {
        #region Attributes
        private readonly IConstantesBusiness _constantesBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Se crear una instancia para <see cref="ConstantesController"/> class.
        /// </summary>
        /// <param name="constantesBusiness">The constantes business.</param>
        public ConstantesController(IConstantesBusiness constantesBusiness)
        {
            _constantesBusiness = constantesBusiness;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Permite obtener una lista de constantes de acuerdo al idPadre
        /// </summary>
        /// <returns></returns>
        [HttpGet("getByIdPadre/{idPadre}")]
        public async Task<ActionResult> getAllConstantesByIdPadre(int idPadre)
        {
            var result = await _constantesBusiness.GetAllConstantesByIdPadre(idPadre);
            
            return StatusCode(result.Code, result);
        }

        [HttpGet("bpm/prueba")]
        public async Task<ActionResult> prueba()
        {
            var result = await _constantesBusiness.bmp();

            return StatusCode(result.Code, result);
        }
        #endregion
    }
}