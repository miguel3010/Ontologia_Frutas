using DataSource;
using Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace REST_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConsultorController : ApiController
    {
        [HttpPost]
        [Route("api/consulta/")]
        public IHttpActionResult Idioma(Fruta parametro)
        {
            Ontologia service = new Ontologia();
            List<Fruta> recursos = service.consulta(parametro);
            return Ok(recursos);
        }

        [HttpGet]
        [Route("api/resource/{resource}")]
        public IHttpActionResult getResource(string resource)
        {

            Ontologia service = new Ontologia();
            RecursoRDF res = service.getRecurso(resource);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/resource/fruta/")]
        public IHttpActionResult addNewFruta(Fruta resource)
        {
            if (resource != null)
            {
                Ontologia service = new Ontologia();
                if (service.crearFruta(resource))
                {
                    return Ok();
                }
                else {
                    return InternalServerError();
                }
            }
            return BadRequest("Insufisiencia de datos");
        }

        [HttpDelete]
        [Route("api/resource/fruta/{resourceName}")]
        public IHttpActionResult deleteFruta(string resourceName)
        {
            new Ontologia().deleteFruta(resourceName);
            return Ok();
        }

    }


}