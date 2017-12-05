export class Fruta {
  nombre_cientifico: string;
  nombre_Comun: string;
  colores: string[];
  agua: number;
  mineral: Mineral[];
  textura: string;
  sabor: string;
  region: string[];
  vitamina: Vitamina[];
  recurso: string;
  clases: any[];
  type: string;

  constructor(){
    this.nombre_cientifico = "";
   
    this.nombre_Comun = "";
    this.colores = new Array();
    this.agua = 0;
    this.mineral = new Array();
    this.textura = "";
    this.sabor = "";
    this.region = new Array();
    this.vitamina = new Array();
    this.recurso = "";
    this.clases = new Array();
    this.type = "";

  }
}

export class Vitamina {
  tipo: any;
  nombre_cientifico: string;
  nombre_comun: string;
  descripcion: string;
  peso_molar: string;
  punto_ebullicion: string;
  punto_fusion: string;
  recurso: string;
  clases: any[];
  type: string;
}

export class ParametroBusqueda
{
    
    colores: string[];
    mineral: string;
    region: string[]; 
    sabor: string;
    vitamina: string;

    constructor(){
      
      this.colores = new Array();
      
      this.mineral = ""; 
      this.sabor = "";
      this.colores = new Array();
      this.region = new Array();
      this.vitamina = "";  
  
    }
}

 

export class Mineral {
  nombre_cientifico: string;
  nombre_comun: string;
  simbolo_quimico: string;
  recurso: string;
  clases: string[];
  type: string;
}

