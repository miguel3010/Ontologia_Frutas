import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PresentacionViewComponent } from './presentacion-view.component';

describe('PresentacionViewComponent', () => {
  let component: PresentacionViewComponent;
  let fixture: ComponentFixture<PresentacionViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PresentacionViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PresentacionViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
