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

        [HttpPost] // Probada y funcionando
        [Route("SPCargaEditables")]
        public IActionResult SPcargaEditables([FromBody] REQUEST_EDITABLES data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.CargaEditable(data));
        }

        [HttpPost] //Probada y funcionando
        [Route("SPDescargaFechas")]
        public IActionResult descargaFechas([FromBody] REQUEST_FECHAS data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.DescargaFechas(data));
        }

        [HttpPost] //Probada y funcionando
        [Route("SPFiltro")]
        public IActionResult filtroDatos([FromBody] REQUEST_FILTRO data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.FiltraDatos(data.filtro));
        }

        [HttpPost] //Probada y funcionando
        [Route("SPExamina")]
        public IActionResult examinarDatos([FromBody] REQUEST_FILTRO data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.ExaminaDatos(data.filtro));
        }

        [HttpPost] //Probada y funcionando ultimo borrado "62"
        [Route("SPEliminar")]
        public IActionResult eliminarDatos([FromBody] REQUEST_ID data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.Eliminado(data.id));
        }

        [HttpGet] // Probada y funcionando
        [Route("SPLeeFimype")]
        public IActionResult getFimype()
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.TablaFimype());
        }

        [HttpPost] // Probada y funcionando
        [Route("SPfiltroFMP")]
        public IActionResult filtradofimype([FromBody] REQUEST_FILTRO data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.Filtrado(data.filtro));
        }

        [HttpPost] // Probada y funcionando
        [Route("SPreporteFMP")]
        public IActionResult reporteFMP([FromBody] REQUEST_FECHAS data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.Descarga(data.fechaIni, data.fechaFin));
        }

        [HttpPost] // Probada y funcionando
        [Route("SPhistorico")]
        public IActionResult reporteFMP([FromBody] REQUEST_FILTRO data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.FechasT(data.filtro));
        }

    }
}
