import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarFrutaComponent } from './agregar-fruta.component';

describe('AgregarFrutaComponent', () => {
  let component: AgregarFrutaComponent;
  let fixture: ComponentFixture<AgregarFrutaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregarFrutaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarFrutaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
