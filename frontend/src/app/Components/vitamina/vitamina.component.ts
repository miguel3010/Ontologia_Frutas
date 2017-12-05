import { Component, OnInit, Input } from '@angular/core';
import { Vitamina } from '../../model';

@Component({
  selector: 'app-vitamina',
  templateUrl: './vitamina.component.html',
  styleUrls: ['./vitamina.component.css']
})
export class VitaminaComponent implements OnInit {

  constructor() { }
  @Input() public model: Vitamina;
  ngOnInit() {
     console.log(this.model);
  }

}
