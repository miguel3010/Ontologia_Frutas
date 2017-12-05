import { stringify } from 'querystring';
import { Component, OnInit, Input,ElementRef,ViewChild } from '@angular/core'; 
import { Fruta, ParametroBusqueda } from '../../model';
import { ApiService } from '../../Services/api.service';
import { ResultadosComponent } from '../resultados/resultados.component'; 
declare var jQuery: any;
@Component({
  selector: 'app-param-busqueda',
  templateUrl: './param-busqueda.component.html',
  styleUrls: ['./param-busqueda.component.css']
})
export class ParamBusquedaComponent implements OnInit {

  @Input() public editor = false;
  @ViewChild('consultaModal') myModal: ElementRef;
  public color: string;
  public mineral: string;
  public sabor: string;
  public regin: string;
  public vitamina: string;

  @Input() res: ResultadosComponent;

  constructor(private api:ApiService) { }

  ngOnInit() {
  }

  consulta(){
    let f = new ParametroBusqueda();
    if(this.color != null && this.color != ""){
      f.colores = this.color.split(',');
    }

    if(this.regin != null){
      f.region = this.regin.split(',');
    }

    if(this.sabor != null){
      f.sabor = this.sabor;
    }

    if(this.mineral != null){
      f.mineral = this.mineral;
    }
    
    if(this.vitamina != null){
      f.vitamina = this.vitamina;
    }



    console.log(f);
    this.api.consulta(f).subscribe(response => {
       this.res.results = response.json();
       this.res.iniciado = true;       
       jQuery(this.myModal.nativeElement).modal('hide');
    }, error => {
      alert('Parametros de Simulación no pudieron ser obtenidos');
    }); 

  }

}
 