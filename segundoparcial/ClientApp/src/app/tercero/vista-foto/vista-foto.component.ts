import { Component, OnInit } from '@angular/core';
import { SubirfotoService } from 'src/app/services/subirfoto.service';
import { VistaImagenTercero } from '../models/vista-imagen-tercero';


@Component({
  selector: 'app-vista-foto',
  templateUrl: './vista-foto.component.html',
  styleUrls: ['./vista-foto.component.css']
})
export class VistaFotoComponent implements OnInit {

  vistaImagenTerceros : VistaImagenTercero[];
  

  constructor(private subirfotoService: SubirfotoService) { }

  ngOnInit(): void {
    this.subirfotoService.get().subscribe(result =>
      {this.vistaImagenTerceros =  result;
    });
  }

}
