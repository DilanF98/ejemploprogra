using AccesoDatos.Entidades;
using Entidades.EntidadesPropias;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiProgramacion06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionesController : ControllerBase
    {
        private readonly ICountryRegionLN gObjRegionesLN = new CountryRegionLN();
        private readonly ICountryRegionPALN gObjRegionesPALN;

        public RegionesController(IConfiguration pConfig)
        {
            gObjRegionesPALN = new CountryRegionPALN(pConfig.GetConnectionString("AWCnx"));
        }

        /***************************ENTIDADES**********************************/

        [HttpGet]
        [Route("[action]")]        
        public List<CountryRegion> obtenerRegiones()
        {
            return gObjRegionesLN.obtenerRegiones();
        }

        [HttpGet]
        [Route("[action]/{pIdRegion}")]
        public CountryRegion obtenerRegion(string pIdRegion)
        {
            return gObjRegionesLN.obtenerRegion(pIdRegion);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult insRegion([FromBody]CountryRegion pRegion)
        {
            if (ModelState.IsValid)
            {
                gObjRegionesLN.insRegion(pRegion);
                return Ok(pRegion);
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult modRegion([FromBody] CountryRegion pRegion)
        {
            if (ModelState.IsValid)
            {
                gObjRegionesLN.modRegion(pRegion);
                return Ok(pRegion);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("[action]/{pIdRegion}")]
        public IActionResult delRegion(string pIdRegion)
        {
            if (ModelState.IsValid)
            {
                var existe = gObjRegionesLN.obtenerRegion(pIdRegion);
                if(existe != null)
                {
                    gObjRegionesLN.delRegion(existe);
                    return Ok(existe);
                }
                else
                {
                    return BadRequest("La región a eliminar no existe, verifique.");
                }                
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /***************************PROCEDIMIENTOS ALMACENADOS**********************************/
        [HttpGet]
        [Route("[action]")]
        public List<RegionesPA> obtenerRegionesPA()
        {
            return gObjRegionesPALN.obtenerRegionesPA();
        }

        [HttpGet]
        [Route("[action]/{pIdRegion}")]
        public RegionesPA obtenerRegionPA(string pIdRegion)
        {
            return gObjRegionesPALN.obtenerRegionPA(pIdRegion);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult insRegionPA([FromBody] RegionesPA pRegion)
        {
            if (ModelState.IsValid)
            {
                gObjRegionesPALN.insRegionPA(pRegion);
                return Ok(pRegion);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult modRegionPA([FromBody] RegionesPA pRegion)
        {
            if (ModelState.IsValid)
            {
                gObjRegionesPALN.modRegionPA(pRegion);
                return Ok(pRegion);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("[action]/{pIdRegion}")]
        public IActionResult delRegionPA(string pIdRegion)
        {
            if (ModelState.IsValid)
            {
                var existe = gObjRegionesPALN.obtenerRegionPA(pIdRegion);
                if (existe != null)
                {
                    gObjRegionesPALN.delRegionPA(existe);
                    return Ok(existe);
                }
                else
                {
                    return BadRequest("La región a eliminar no existe, verifique.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
