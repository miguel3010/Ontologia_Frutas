import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemResultadoComponent } from './item-resultado.component';

describe('ItemResultadoComponent', () => {
  let component: ItemResultadoComponent;
  let fixture: ComponentFixture<ItemResultadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemResultadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemResultadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
