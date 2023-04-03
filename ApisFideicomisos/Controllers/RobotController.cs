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
        public IActionResult spInterfaz()
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.GetFullTFideicomisos());
        }

        [HttpPost] // Probada y funcionando
        [Route("SPPosicion")]
        public IActionResult spPosicion([FromBody] REQUEST_ID data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.GetFideicomisosById(data));
        }

        [HttpPost] // Revisar
        [Route("SPCargaEditables")]
        public IActionResult SPcargaEditables([FromBody] REQUEST_EDITABLES data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.CargaEditable(data));
        }

        [HttpPost] //Probaday funcionando
        [Route("SPDescargaFechas")]
        public IActionResult descargaFechas([FromBody] REQUEST_FECHAS data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.DescargaFechas(data));
        }

        [HttpPost] //Probaday funcionando
        [Route("SPFiltro")]
        public IActionResult filtroDatos([FromBody] REQUEST_FILTRO data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.FiltraDatos(data.filtro));
        }


    }
}
