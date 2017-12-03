export class Fruta {
    nombre_cientifico: string;
    nombre_Comun: string;
    colores: string[];
    agua: number;
    mineral: Mineral;
    textura: string;
    sabor: string;
    region: Region;
    vitamina: Vitamina;
  }
  
  export class Vitamina {
    nombre_cientifico: string;
    nombre_comun: string;
    descripcion: string;
    peso_molar: number;
    punto_ebullicion: number;
    punto_fusion: number;
  }
  
  export class Region {
  }
  
  export class Mineral {
    nombre_cientifico: string;
    nombre_comun: string;
    simbolo_quimico: string;
  }