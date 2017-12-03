using System.Collections.Generic;

namespace Models
{
    public class Fruta : RecursoRDF
    {
        public string nombre_cientifico;
        public string nombre_Comun;
        public List<string> colores;
        public float agua;
        public Minerales mineral;
        public string Textura;
        public string Sabor;
        public Region Región;
        public Vitamina vitamina;
    }
}