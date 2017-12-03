import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Param-BusquedaComponent } from './param--busqueda.component';

describe('Param-BusquedaComponent', () => {
  let component: Param-BusquedaComponent;
  let fixture: ComponentFixture<Param-BusquedaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Param-BusquedaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Param-BusquedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
