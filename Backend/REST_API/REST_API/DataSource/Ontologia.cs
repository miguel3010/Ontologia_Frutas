using Models;
using System.Collections.Generic;
using VDS.RDF.Storage;
using VDS.RDF;
using VDS.RDF.Query;
using System;

namespace DataSource
{
    public class Ontologia
    {
        private static string baseURL = @"http://localhost:3030/ontofrutis/data";
        public static List<RecursoRDF> resources;

        public string rdf = "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>";
        public string rdfs = "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>";
        public string data = "PREFIX data:  <http://localhost:3030/ontofrutis/data#>";

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
                if (item.GetType() == typeof(Fruta))
                {
                    res.Add((Fruta)item);
                }
            }
            return res;
        }

        public RecursoRDF getRecurso(string resource)
        {
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = "SELECT DISTINCT  ?d WHERE { data:" + resource + " a ?class . ?class rdfs:subClassOf ?d } ";
            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());


            if (e is SparqlResultSet)
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                string a;
                if (res1.IsEmpty)
                {
                    a = "Mineral";
                }
                else
                {
                    a = (string)res1[0][0].ToString();
                    a = getResourceString(a);
                }
                switch (a)
                {
                    case "Vitamina":
                        return readVitamina(resource);
                    case "Mineral":
                        return readMineral(resource);
                    case "Fruta":
                        return readFruta(resource);
                }
            }
            return null;
        }

        public bool crearFruta(Fruta res)
        {
            if (res != null)
            {
                Ontologia.resources.Add(res);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Proceso de eliminación de nodo RDF/OWL en el servidor Fuseki
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool deleteFruta(string res)
        {
            try
            {
                RecursoRDF ress = getRecurso(res);
                if (ress != null)
                {
                    FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
                    fuseki.DeleteGraph(new Uri(Ontologia.baseURL + "#" + res));
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }
        /// <summary>
        /// Lectura de recurso de tipo Fruta
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private Fruta readFruta(string resource)
        {
            Fruta res = null;
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = "Select distinct ?nombreComun ?nombreCientifico ?color ?sabor ?textura ?agua ?mineral ?vitamina" +
                                "Where {" +
                                "  data:" + resource + " data:nombreComunFruta ?nombreComun. " +
                                "  data:" + resource + " data:nombreCientificoFruta ?nombreCientifico. " +
                                "  data:" + resource + " data:tieneColor ?color. " +
                                "  data:" + resource + " data:tieneSabor ?sabor. " +
                                "  data:" + resource + " data:tieneTextura ?textura. " +
                                "  data:" + resource + " data:tieneAgua ?agua. " +
                                "  data:" + resource + " data:tieneMineral ?mineral. " +
                                "  data:" + resource + " data:tieneVitamina ?vitamina. " +
                                "}";
            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                res = new Fruta();

                var item = res1[0];
                res.recurso = resource;
                res.type = "Fruta";
                res.nombre_Comun = (string)item[0].ToString();
                res.nombre_cientifico = (string)item[1].ToString();
                res.colores = new List<string>(item[2].ToString().Split(','));
                res.sabor = (string)item[3].ToString();
                res.textura = (string)item[4].ToString();
                string dd = item[5].ToString();
                dd = dd.Remove(dd.IndexOf('g')).Trim();
                res.agua = (int)Convert.ToDouble(dd);
                res.mineral = getMinerales(resources);
                res.vitamina = getVitaminas(resources);


            }
            catch (Exception ex) { }

            return res;
        }

        private List<Vitamina> getVitaminas(List<RecursoRDF> resources)
        {
            return null;
        }

        private List<Minerales> getMinerales(List<RecursoRDF> resources)
        {
            return null;
        }

        /// <summary>
        /// Lectura de recurso de tipo Mineral
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private Minerales readMineral(string resource)
        {
            Minerales res = null;
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = "Select ?nombreComun ?nombreCientifico ?simboloQuimico " +
                                    "Where { " +
                                        "data:" + resource + " data:nombreComunMineral ?nombreComun. " +
                                        "data:" + resource + " data:simboloQuimicoMineral ?nombreCientifico. " +
                                        "data:" + resource + " data:nombreCientificoMineral ?simboloQuimico. " +
                                    "}";

            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                res = new Minerales();

                var item = res1[0];
                res.type = "Mineral";
                res.recurso = resource;
                res.nombre_comun = (string)item[0].ToString();
                res.nombre_cientifico = (string)item[1].ToString();
                res.simbolo_quimico = (string)item[2].ToString();

            }
            catch (Exception ex) { }

            return res;
        }
        /// <summary>
        /// Lectura de recurso de tipo Vitamina
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private Vitamina readVitamina(string resource)
        {
            Vitamina res = null;
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = "Select ?nombreComun ?nombreReal ?descripcion ?puntodeEbu ?puntodeFu ?pesoMolar " +
                                    "Where { " +
                                    "  data:" + resource + " data:nombreComunVitamina ?nombreComun. " +
                                    "  data:" + resource + " data:nombreRealVitamina ?nombreReal. " +
                                    "  data:" + resource + " data:descripcionVitamina ?descripcion. " +
                                    "  data:" + resource + " data:puntodeEbullisionVitamina ?puntodeEbu. " +
                                    "  data:" + resource + " data:puntodeFusionVitamina ?puntodeFu. " +
                                    "  data:" + resource + " data:pesoMolarVitamina ?pesoMolar. " +
                                    "}";
            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                res = new Vitamina();

                var item = res1[0];
                res.recurso = resource;
                res.type = "Vitamina";
                res.nombre_comun = (string)item[0].ToString();
                res.nombre_cientifico = (string)item[1].ToString();
                res.descripcion = (string)item[2].ToString();


                string dd = item[3].ToString();
                if (dd != "null")
                {
                    dd = dd.Remove(dd.IndexOf("°C")).Trim();
                    res.punto_ebullicion = (int)Convert.ToDouble(dd);
                }

                dd = item[4].ToString();
                dd = dd.Remove(dd.IndexOf("°C")).Trim();
                res.punto_fusion = (int)Convert.ToDouble(dd);

                dd = item[5].ToString();
                dd = dd.Remove(dd.IndexOf("g/mol")).Trim();
                res.peso_molar = (int)Convert.ToDouble(dd);



            }
            catch (Exception ex) { }

            return res;
        }
        /// <summary>
        /// Obtiene el recurso sin URL/URI
        /// </summary>
        /// <param name="rawResource"></param>
        /// <returns></returns>
        public string getResourceString(string rawResource)
        {
            return rawResource.Substring(rawResource.IndexOf("#") + 1);
        }
    }
}