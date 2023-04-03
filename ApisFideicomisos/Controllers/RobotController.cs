using ApisFideicomisos.Handlers;
using ApisFideicomisos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApisFideicomisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {

        [HttpGet] // Probada y funcionando
        [Route("SPInterfaz")]
        public IActionResult solicitudEnvios()
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.GetFullTFideicomisos());
        }

        [HttpPost] // Probada y funcionando
        [Route("SPPosicion")]
        public IActionResult solicitudEnvios([FromBody] REQUEST_ID data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.GetFideicomisosById(data));
        }


    }
}
