using Models;
using System.Collections.Generic;

namespace DataSource
{
    public class Ontologia
    {
        public static List<RecursoRDF> resources;

        public Ontologia()
        {
            if (Ontologia.resources == null)
            {
                Ontologia.resources = new List<RecursoRDF>();
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
                m.type = "Mineral";
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

                Ontologia.resources.Add(f);
                Ontologia.resources.Add(m);
                Ontologia.resources.Add(v); 
            }
        }
        
        public List<Fruta> consulta(ParametroBusqueda param)
        {
            List<Fruta> res = new List<Fruta>();

            foreach (var item in Ontologia.resources)
            {
                if (item.GetType() == typeof(Fruta)) {
                    res.Add((Fruta)item);
                }
            }
            return res;
        }

        public RecursoRDF getRecurso(string resource)
        {
            RecursoRDF res = null;
            foreach (var item in Ontologia.resources)
            {
                if (item.recurso == resource)
                {
                    res = item;
                    break;
                }
            }
            return res;
        }

        public bool crearFruta(Fruta res)
        {
            if (res != null)
            {
                Ontologia.resources.Add(res);
            }
            return false;
        }

        public bool deleteFruta(string res)
        {
            if (!string.IsNullOrEmpty(res))
            {
                foreach (var item in Ontologia.resources)
                {
                    if (item.recurso == res) {
                        Ontologia.resources.Remove(item);
                        break;
                    }
                }
            }
            return false;
        }
    }
}