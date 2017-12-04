import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { Fruta } from '../../model';


@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.css']
})
export class ResultadosComponent implements OnInit {

  @Input() public editorCheck: boolean;
  @Input() public results: Fruta[];

  constructor(private _router: Router) {
    this.editorCheck = false;
   }

  ngOnInit() {
  }

  redireccionToFrutas(model: Fruta) {
    this._router.navigate(['recurso/' + model.recurso]);
  }
}
