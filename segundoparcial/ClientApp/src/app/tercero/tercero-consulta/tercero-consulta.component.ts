import { Component, OnInit } from '@angular/core';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';

@Component({
  selector: 'app-tercero-consulta',
  templateUrl: './tercero-consulta.component.html',
  styleUrls: ['./tercero-consulta.component.css']
})
export class TerceroConsultaComponent implements OnInit {
  searchText: string;
  terceros: Tercero[];
  constructor(private terceroService: TerceroService) { }

  ngOnInit(): void {
    this.terceroService.get().subscribe(result => {
      this.terceros = result;
    });
  }

}
