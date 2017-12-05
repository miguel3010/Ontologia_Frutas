import { Fruta } from './../../model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../../Services/api.service';
import { ResultadosComponent } from '../../Components/resultados/resultados.component';
import { Router } from '@angular/router';
 

@Component({
  selector: 'app-consulta-view',
  templateUrl: './consulta-view.component.html',
  styleUrls: ['./consulta-view.component.css']
})
export class ConsultaViewComponent implements OnInit {

  @ViewChild('res')
  public res: ResultadosComponent;

  constructor(private api: ApiService, private _router: Router) { 

  }

  ngOnInit() { 

  }

  redireccionToFrutas(model: Fruta) {
    this._router.navigate(['recurso/' + model.recurso]);
  }

}
