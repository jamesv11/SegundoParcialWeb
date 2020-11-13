import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';
import { TerceroRegistroComponent } from '../tercero-registro/tercero-registro.component';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {


  constructor(private terceroService: TerceroService,private modalService: NgbModal) { }

  
  Terceros : Tercero[] = [];
  ngOnInit(): void {

  }

  AbrirRegistro(){
    const consultaBox = this.modalService.open(TerceroRegistroComponent); 
   
  }

  Verificar()
  {
    this.AbrirRegistro();
  }

}
