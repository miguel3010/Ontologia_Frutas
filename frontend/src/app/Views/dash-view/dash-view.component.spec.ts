import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashViewComponent } from './dash-view.component';

describe('DashViewComponent', () => {
  let component: DashViewComponent;
  let fixture: ComponentFixture<DashViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
