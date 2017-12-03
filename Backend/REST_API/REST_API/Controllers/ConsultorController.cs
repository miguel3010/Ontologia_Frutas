using Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace REST_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConsultorController : ApiController
    {
        [HttpGet]
        [Route("api/consulta/")]
        public IHttpActionResult Idioma(ParametroBusqueda parametro)
        {
            List<RecursoRDF> recursos = null;
            return Ok(recursos);
        } 
    }
}