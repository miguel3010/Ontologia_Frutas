import { Component, OnInit, Input } from '@angular/core';
import { Mineral } from '../../model';

@Component({
  selector: 'app-mineral',
  templateUrl: './mineral.component.html',
  styleUrls: ['./mineral.component.css']
})
export class MineralComponent implements OnInit {

  constructor() { }
  @Input() public model:Mineral;
  ngOnInit() {
  }

}
