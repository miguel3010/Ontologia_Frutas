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
        public IHttpActionResult Idioma(ParametroBusqueda parametro)
        {
            Ontologia service = new Ontologia();

            Fruta a = new Fruta();
            a.colores = parametro.colores;
            a.region = parametro.region;
            a.sabor = parametro.sabor;
            if (!string.IsNullOrEmpty(parametro.mineral))
            {
                string[] minerales;
                if (parametro.vitamina.IndexOf(',') > 0)
                {
                    minerales = parametro.mineral.Split(',');
                }
                else
                {
                    minerales = new string[1];
                    minerales[0] = parametro.vitamina;
                }
                List<Minerales> m = new List<Minerales>();
                foreach (var item in minerales)
                {
                    Minerales curr = (Minerales)service.getRecurso(item);
                    if (curr != null) {
                        m.Add(curr);
                    }
                }
                a.mineral = m;

            }

            if (!string.IsNullOrEmpty(parametro.vitamina))
            {
                string[] minerales;
                if (parametro.vitamina.IndexOf(',') > 0)
                {
                    minerales = parametro.mineral.Split(',');
                }
                else {
                    minerales = new string[1];
                    minerales[0] = parametro.vitamina;
                }
                List<Vitamina> m = new List<Vitamina>();
                foreach (var item in minerales)
                {
                    Vitamina curr = (Vitamina)service.getRecurso(item);
                    if (curr != null)
                    {
                        m.Add(curr);
                    }
                }
                a.vitamina = m;
            }
            List<Fruta> recursos = service.consulta(a);
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
                else
                {
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