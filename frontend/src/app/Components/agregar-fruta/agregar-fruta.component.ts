import { Fruta } from './../../model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-agregar-fruta',
  templateUrl: './agregar-fruta.component.html',
  styleUrls: ['./agregar-fruta.component.css']
})
export class AgregarFrutaComponent implements OnInit {

  model: Fruta;
  constructor() {
    this.model = new Fruta();
  }

  ngOnInit() { 
  }

}
