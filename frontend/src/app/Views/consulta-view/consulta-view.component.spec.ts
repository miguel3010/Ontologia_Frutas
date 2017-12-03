import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaViewComponent } from './consulta-view.component';

describe('ConsultaViewComponent', () => {
  let component: ConsultaViewComponent;
  let fixture: ComponentFixture<ConsultaViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultaViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
