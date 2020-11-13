import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagoRegistroComponent } from './pago-registro.component';

describe('PagoRegistroComponent', () => {
  let component: PagoRegistroComponent;
  let fixture: ComponentFixture<PagoRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagoRegistroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PagoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
