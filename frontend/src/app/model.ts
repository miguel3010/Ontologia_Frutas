export class Fruta {
  nombre_cientifico: string;
  nombre_Comun: string;
  colores: string[];
  agua: number;
  mineral: Mineral[];
  textura: string;
  sabor: string;
  region: Region[];
  vitamina: Vitamina[];
  recurso: string;
  clases: any[];
  type: string;
}

export class Vitamina {
  tipo: any;
  nombre_cientifico: string;
  nombre_comun: string;
  descripcion: string;
  peso_molar: number;
  punto_ebullicion: number;
  punto_fusion: number;
  recurso: string;
  clases: any[];
  type: string;
}

export class Region {
  recurso: string;
  clases: string[];
  type: string;
}

export class Mineral {
  nombre_cientifico: string;
  nombre_comun: string;
  simbolo_quimico: string;
  recurso: string;
  clases: string[];
  type: string;
}

