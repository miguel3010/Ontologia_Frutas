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
            List<RecursoRDF> recursos = new List<RecursoRDF>();

            Fruta f = new Fruta();
            f.colores = new List<string>();
            f.colores.Add("Rojo");
            f.nombre_cientifico = "cse";
            f.nombre_Comun = "wefve";
            f.sabor = "Amargo";
            f.textura = "fcedc";
            f.agua = 90;
            f.recurso = "naranja_ingertada";
            f.type = "Frutas";

            Minerales m = new Minerales();
            m.nombre_cientifico = "nn";
            m.nombre_comun = "cwdc";
            m.simbolo_quimico = "H";
            f.mineral.Add(m);
            
            f.region.Add(new Region());           

            Vitamina v = new Vitamina();
            v.descripcion = "daec";
            v.nombre_cientifico = "ceadc";
            v.nombre_comun = "cads";
            v.peso_molar = 324;
            v.punto_ebullicion = 2434;
            v.punto_fusion = 235;
            f.vitamina.Add(v);

            
            recursos.Add(f);

            return Ok(recursos);
        }

        [HttpGet]
        [Route("api/resource/{resource}")]
        public IHttpActionResult getResource(string resource) {

            if (resource == "naranja")
            {
                Fruta f = new Fruta();

                f.colores = new List<string>();
                f.colores.Add("Rojo");
                f.nombre_cientifico = "Naranjae";
                f.nombre_Comun = "Naranja";
                f.sabor = "Amargo";
                f.textura = "Lisa";
                f.agua = 90;
                f.recurso = "naranja";
                f.type = "Fruta"; 

                Minerales m = new Minerales();
                m.recurso = "calcio";
                m.nombre_cientifico = "calcium";
                m.nombre_comun = "Calcio";
                m.simbolo_quimico = "Ca";
                f.mineral = new List<Minerales>();
                f.mineral.Add(m);

                f.region = new List<Region>();
                f.region.Add(new Region());

                Vitamina v = new Vitamina();
                v.descripcion = "daec";
                v.recurso = "vitamina-c";
                v.nombre_cientifico = "Vitaminac";
                v.nombre_comun = "Vitamina C";
                v.peso_molar = 324;
                v.punto_ebullicion = 2434;
                v.punto_fusion = 235;
                v.type = "Vitamina";
                f.vitamina = new List<Vitamina>();
                f.vitamina.Add(v);

                return Ok(f);
            }
            else if (resource == "vitamina-c")
            {
                Vitamina v = new Vitamina();
                v.descripcion = "daec";
                v.recurso = "vitamina-c";
                v.nombre_cientifico = "Vitaminac";
                v.nombre_comun = "Vitamina C";
                v.peso_molar = 324;
                v.punto_ebullicion = 2434;
                v.punto_fusion = 235;
                v.type = "Vitamina";

                return Ok(v);
            }
            else if (resource == "calcio")
            {
                Minerales m = new Minerales();
                m.recurso = "calcio";
                m.nombre_cientifico = "calcium";
                m.nombre_comun = "Calcio";
                m.simbolo_quimico = "Ca";
                m.type = "Mineral";
                return Ok(m);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/resource/fruta/")]
        public IHttpActionResult addNewFruta(Fruta resource) {
            return Ok();
        }

        [HttpDelete]
        [Route("api/resource/fruta/{resourceName}")]
        public IHttpActionResult deleteFruta(string resourceName) {
            return Ok();
        }

    }

    
}