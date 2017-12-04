import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { Fruta } from '../../model';
import { ApiService } from '../../Services/api.service';


@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.css']
})
export class ResultadosComponent implements OnInit {

  @Input() public editorCheck: boolean;
  @Input() public results: Fruta[];

  constructor(private _router: Router, private api: ApiService) {
    this.editorCheck = false;
  }

  ngOnInit() {
  }

  redireccionToFrutas(model: Fruta) {
    this._router.navigate(['recurso/' + model.recurso]);
  }

  eliminarFruta(model: Fruta) {
    this.api.eliminarFruta(model.recurso).subscribe(response => {
      this.results.splice(this.results.indexOf(model), 1);
    }, error => {
      alert('El recurso no ha podido ser eliminado');
    }); 
  }

}
