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
            List<RecursoRDF> recursos = new List<RecursoRDF>();

            Fruta f = new Fruta();
            f.colores = new List<string>();
            f.colores.Add("Rojo");
            f.nombre_cientifico = "cse";
            f.nombre_Comun = "wefve";
            f.Sabor = "Amargo";
            f.Textura = "fcedc";
            f.agua = 90;
            f.recurso = "naranja_ingertada";

            Minerales m = new Minerales();
            m.nombre_cientifico = "nn";
            m.nombre_comun = "cwdc";
            m.simbolo_quimico = "H";
            f.mineral = m;
            
            f.Región = new Region();           

            Vitamina v = new Vitamina();
            v.descripcion = "daec";
            v.nombre_cientifico = "ceadc";
            v.nombre_comun = "cads";
            v.peso_molar = 324;
            v.punto_ebullicion = 2434;
            v.punto_fusion = 235;
            f.vitamina = v;

            recursos.Add(f);
            f.recurso = "piña";
            recursos.Add(f);

            return Ok(recursos);
        }



    }
}