import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-consulta',
  templateUrl: './pago-consulta.component.html',
  styleUrls: ['./pago-consulta.component.css']
})
export class PagoConsultaComponent implements OnInit {
  searchText: string;
  pagos: Pago[];
  constructor(private pagoService: PagoService) { }

  ngOnInit(): void {
    this.pagoService.get().subscribe(result => {
      this.pagos = result;
    });
  }

}
