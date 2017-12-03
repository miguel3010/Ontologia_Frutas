﻿using System.Collections.Generic;

namespace Models
{
    public class Fruta : RecursoRDF
    {
        public string nombre_cientifico;
        public string nombre_Comun;
        public List<string> colores;
        public float agua;
        public Minerales mineral;
        public string textura;
        public string sabor;
        public Region region;
        public Vitamina vitamina;
    }
}