import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagoConsultaComponent } from './pago-consulta.component';

describe('PagoConsultaComponent', () => {
  let component: PagoConsultaComponent;
  let fixture: ComponentFixture<PagoConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagoConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PagoConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
