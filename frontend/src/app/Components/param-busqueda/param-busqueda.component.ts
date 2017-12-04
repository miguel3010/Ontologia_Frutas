import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';

@Component({
  selector: 'app-param-busqueda',
  templateUrl: './param-busqueda.component.html',
  styleUrls: ['./param-busqueda.component.css']
})
export class ParamBusquedaComponent implements OnInit {

  @Input() public editor = false;
  constructor() { }

  ngOnInit() {
  }

}
