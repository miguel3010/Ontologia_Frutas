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

  constructor() {
    this.editorCheck = false;
   }

  ngOnInit() {
  }



}
