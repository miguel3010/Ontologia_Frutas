import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MineralComponent } from './mineral.component';

describe('MineralComponent', () => {
  let component: MineralComponent;
  let fixture: ComponentFixture<MineralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MineralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MineralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
