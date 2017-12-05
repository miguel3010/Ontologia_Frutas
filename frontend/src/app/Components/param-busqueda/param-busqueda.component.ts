import { stringify } from 'querystring';
import { Component, OnInit, Input,ElementRef,ViewChild } from '@angular/core'; 
import { Fruta } from '../../model';
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
    let f = new Fruta();
    if(this.color != null){
      f.colores = this.color.split(',');
    }

    if(this.regin != null){
      f.region = this.regin.split(',');
    }

    if(this.sabor != null){
      f.sabor = this.sabor;
    }

    

    console.log(stringify(f));
    this.api.consulta(f).subscribe(response => {
       this.res.results = response.json();
       this.res.iniciado = true;       
       jQuery(this.myModal.nativeElement).modal('hide');
    }, error => {
      alert('Parametros de Simulación no pudieron ser obtenidos');
    }); 

  }

}
 