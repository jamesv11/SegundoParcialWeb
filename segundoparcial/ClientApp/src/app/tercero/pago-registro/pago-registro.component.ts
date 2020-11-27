import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { PagoService } from 'src/app/services/pago.service';
import { TerceroService } from 'src/app/services/tercero.service';
import { Pago } from '../models/pago';
import { Tercero } from '../models/tercero';
import { TerceroRegistroComponent } from '../tercero-registro/tercero-registro.component';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {


  constructor(private pagoService : PagoService,private formBuilder :  FormBuilder  ,private modalService: NgbModal,
    private terceroService : TerceroService) { }

  identificacion : string;
  submitted = false;
  registerPagoForm : FormGroup; 
  pago : Pago;
  ngOnInit(): void {

    this.pago =  new Pago();
    this.pago.terceroIdentificacion = "";
    this.pago.tipoPago = "Seleccione...";
    this.pago.fechaPago = new Date;
    this.pago.valorPago = null;
    this.pago.iva = null;

    this.registerPagoForm = this.formBuilder.group(
      {
        terceroIdentificacion : [this.pago.terceroIdentificacion,Validators.required],
        tipoPago : [this.pago.tipoPago,Validators.required],
        fechaPago : "",
        valorPago : [this.pago.valorPago,Validators.required],
        iva : [this.pago.iva,Validators.required]
      }
    );

  }

  get f() { return this.registerPagoForm.controls; }

  OnSubmit() {
    this.submitted = true;
    if (this.registerPagoForm.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.pago = this.registerPagoForm.value;
    console.log(this.pago);
    this.pagoService.post(this.pago).subscribe((p) => {
      if (p != null) {
        console.log(p);
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Proceso terminado";
        messageBox.componentInstance.message = "Exitoso";
        
        this.pago = p;
      }
    });
  }
  onReset() {
    this.submitted = false;
    this.registerPagoForm.reset();
  }
  /*
   pagoId : number;
    terceroIdentificacion : string;
    tipoPago : string;
    fechaPago : Date;
    valorPago : number;
    iva : number; 
  */
  AbrirRegistro(){
    const consultaBox = this.modalService.open(TerceroRegistroComponent); 
   
  }

  Verificar()
  {
      this.BuscarCliente();
    
  }

  BuscarCliente()
 {
    this.terceroService.getId(this.registerPagoForm.value.terceroIdentificacion).subscribe(tercero => 
      {
        if(tercero != null)
        {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Verificacion Terminada";
          messageBox.componentInstance.message = "Se ha encontrado";
        }
        else
        {
          this.AbrirRegistro();
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Verificacion Terminada";
          messageBox.componentInstance.message = "No se ha encontrado";
          
        }
      });
 }

}
