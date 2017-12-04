import { Component, OnInit, Input } from '@angular/core';
import { Fruta } from '../../model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fruta',
  templateUrl: './fruta.component.html',
  styleUrls: ['./fruta.component.css']
})
export class FrutaComponent implements OnInit {

  @Input() public model: Fruta;
  constructor(private _router: Router) { }

  ngOnInit() {
  }

  redirectToResource(res) {
    this._router.navigate(['recurso/'+res.recurso]);
  }

}
