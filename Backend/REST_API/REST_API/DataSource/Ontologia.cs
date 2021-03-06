﻿using Models;
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



                Vitamina v = new Vitamina();
                v.descripcion = "daec";
                v.recurso = "vitamina-c";
                v.nombre_cientifico = "Vitaminac";
                v.nombre_comun = "Vitamina C"; 
                v.type = "Vitamina";
                f.vitamina = new List<Vitamina>();
                f.vitamina.Add(v);

                Ontologia.resources.Add(f);
                Ontologia.resources.Add(m);
                Ontologia.resources.Add(v);
            }
        }
        /// <summary>
        /// Proceso de Busqueda y filtrado de datos en ontología
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Fruta> consulta(Fruta param)
        {
            List<Fruta> resultado = null;
            SparqlParameterizedString query = new SparqlParameterizedString();
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));
            query.Namespaces.AddNamespace("xsd", new Uri("http://www.w3.org/2001/XMLSchema#"));

            query.CommandText = "SELECT ?fruta WHERE { ";
            if (param.region != null && param.region.Count > 0)
            {
                foreach (var item in param.region)
                {
                    query.CommandText += "   ?fruta data:deRegion \"" + item + "\"^^ xsd:string. ";
                }
            }

            if (param.colores != null && param.colores.Count > 0)
            {
                foreach (var item in param.colores)
                {
                    query.CommandText += "   ?fruta data:tieneColor \"" + item + "\"^^ xsd:string. ";
                }
            }

            if (param.mineral != null && param.mineral.Count > 0)
            {
                foreach (var item in param.mineral)
                {
                    query.CommandText += "   ?fruta data:tiene_Mineral data:" + item.recurso + ". ";
                }
            }

            if (param.vitamina != null && param.vitamina.Count > 0)
            {
                foreach (var item in param.vitamina)
                {
                    query.CommandText += "   ?fruta data:tieneVitamina data:" + item.recurso + ". ";
                }
            }

            if (!string.IsNullOrEmpty(param.sabor))
            {
                query.CommandText += " ?fruta data:tieneSabor \"" + param.sabor + "\"^^xsd:string . ";
            }

            query.CommandText += " }";

            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                if (!res1.IsEmpty)
                {
                    resultado = new List<Fruta>();
                    foreach (var item in res1.Results)
                    {
                        Fruta curr = readFruta(getResourceString(item[0].ToString()));
                        if (curr != null)
                        {
                            resultado.Add(curr);
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return resultado;
        }
        /// <summary>
        /// Obtener el recurso especificado según el recurso en cadena de texto
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
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

            query.CommandText = "Select distinct ?nombreComun ?nombreCientifico ?color ?sabor ?textura ?agua ?mineral ?vitamina " +
                                "Where {" +
                                "  data:" + resource + " data:nombreComunFruta ?nombreComun. " +
                                "  data:" + resource + " data:nombreCientificoFruta ?nombreCientifico. " +
                                "  data:" + resource + " data:tieneColor ?color. " +
                                "  data:" + resource + " data:tieneSabor ?sabor. " +
                                "  data:" + resource + " data:tieneTextura ?textura. " +
                                "  data:" + resource + " data:tieneAgua ?agua. " +
                                "  OPTIONAL {data:" + resource + " data:tieneMineral ?mineral. }" +
                                "  OPTIONAL {data:" + resource + " data:tieneVitamina ?vitamina. }" +
                                "}";
            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                if (!res1.IsEmpty)
                {
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
                    res.mineral = getMinerales(resource);
                    res.vitamina = getVitaminas(resource);

                }
            }
            catch (Exception ex) { }

            return res;
        }
        /// <summary>
        /// Lectura de lista de Vitaminas para un recurso fruta dado
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        private List<Vitamina> getVitaminas(string resources)
        {
            List<Vitamina> res = null;
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = " Select ?vitamina Where { data:" + resources + " data:tieneVitamina ?vitamina. }";

            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                if (!res1.IsEmpty)
                {
                    res = new List<Vitamina>();
                    foreach (var item in res1.Results)
                    {
                        Vitamina curr = readVitamina(getResourceString(item[0].ToString()));
                        if (curr != null)
                        {
                            res.Add(curr);
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return res;
        }
        /// <summary>
        /// Lectura de lista de minerales para un recurso fruta dado
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        private List<Minerales> getMinerales(string resources)
        {
            List<Minerales> res = null;
            FusekiConnector fuseki = new FusekiConnector(Ontologia.baseURL);
            PersistentTripleStore pst = new PersistentTripleStore(fuseki);

            SparqlParameterizedString query = new SparqlParameterizedString();
            query.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            query.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            query.Namespaces.AddNamespace("data", new Uri("http://localhost:3030/ontofrutis/data#"));

            query.CommandText = " Select ?mineral  Where { data:" + resources + " data:tieneMineral ?mineral. }";

            Console.Write(query.ToString());
            object e = pst.ExecuteQuery(query.ToString());

            try
            {
                SparqlResultSet res1 = (SparqlResultSet)e;
                if (!res1.IsEmpty)
                {
                    res = new List<Minerales>();
                    foreach (var item in res1.Results)
                    {
                        Minerales curr = readMineral(getResourceString(item[0].ToString()));
                        if (curr != null)
                        {
                            res.Add(curr);
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return res;
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
                if (!res1.IsEmpty)
                {
                    res = new Minerales();
                    var item = res1[0];
                    res.type = "Mineral";
                    res.recurso = resource;
                    res.nombre_comun = (string)item[0].ToString();
                    res.nombre_cientifico = (string)item[1].ToString();
                    res.simbolo_quimico = (string)item[2].ToString();
                }
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
                if (!res1.IsEmpty)
                {
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
                        res.punto_ebullicion = item[3].ToString();
                    }
                     
                    res.punto_fusion = item[4].ToString(); 
                    res.peso_molar = item[5].ToString();

                }

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