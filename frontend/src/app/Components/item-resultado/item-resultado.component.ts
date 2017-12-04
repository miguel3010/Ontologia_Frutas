import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { Fruta } from '../../model';

@Component({
  selector: 'app-item-resultado',
  templateUrl: './item-resultado.component.html',
  styleUrls: ['./item-resultado.component.css']
})
export class ItemResultadoComponent implements OnInit {

  constructor(private _router: Router) { }

  @Input() public model: Fruta;

  ngOnInit() {
  }

  redireccionToFrutas(model: Fruta) {
    this._router.navigate(['recurso/' + model.recurso]);
  }

}
