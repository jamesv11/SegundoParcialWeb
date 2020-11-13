import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerceroRegistroComponent } from './tercero-registro.component';

describe('TerceroRegistroComponent', () => {
  let component: TerceroRegistroComponent;
  let fixture: ComponentFixture<TerceroRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TerceroRegistroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TerceroRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
