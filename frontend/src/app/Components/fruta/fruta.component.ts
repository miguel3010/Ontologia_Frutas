import { Component, OnInit, Input } from '@angular/core'; 
import { Fruta } from '../../model';

@Component({
  selector: 'app-fruta',
  templateUrl: './fruta.component.html',
  styleUrls: ['./fruta.component.css']
})
export class FrutaComponent implements OnInit {

  @Input() public model:Fruta;
  constructor() { }

  ngOnInit() {
  }

}
