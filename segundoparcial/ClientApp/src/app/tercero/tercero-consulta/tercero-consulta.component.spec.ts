import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerceroConsultaComponent } from './tercero-consulta.component';

describe('TerceroConsultaComponent', () => {
  let component: TerceroConsultaComponent;
  let fixture: ComponentFixture<TerceroConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TerceroConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TerceroConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
