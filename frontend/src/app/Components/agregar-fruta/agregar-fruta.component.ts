import { ApiService } from './../../Services/api.service';
import { Fruta } from './../../model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
declare var jQuery: any;
@Component({
  selector: 'app-agregar-fruta',
  templateUrl: './agregar-fruta.component.html',
  styleUrls: ['./agregar-fruta.component.css']
})
export class AgregarFrutaComponent implements OnInit {

  model: Fruta;
  @ViewChild('paramModal') myModal: ElementRef;
  constructor(private api: ApiService) {
    this.model = new Fruta();
  }

  ngOnInit() {
  }

  agregarFruta(model: Fruta) {
    this.api.agregarFruta(model).subscribe(response => {
      jQuery(this.myModal.nativeElement).modal('hide');
    }, error => {
      alert(error.json().message);
    });
  }

}
