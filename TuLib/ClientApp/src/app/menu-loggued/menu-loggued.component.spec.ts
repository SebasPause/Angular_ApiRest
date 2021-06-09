import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuLogguedComponent } from './menu-loggued.component';

describe('MenuLogguedComponent', () => {
  let component: MenuLogguedComponent;
  let fixture: ComponentFixture<MenuLogguedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuLogguedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuLogguedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
