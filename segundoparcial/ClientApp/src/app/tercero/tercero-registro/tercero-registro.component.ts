import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';

@Component({
  selector: 'app-tercero-registro',
  templateUrl: './tercero-registro.component.html',
  styleUrls: ['./tercero-registro.component.css']
})
export class TerceroRegistroComponent implements OnInit {

  

  @Input() Identificacion : string;
  submitted = false
  registrarTerceroForm:FormGroup;
  tercero : Tercero;

  constructor(private modalService: NgbModal,public activeModal: NgbActiveModal,private terceroService : TerceroService,
    private formBuilder : FormBuilder) { }

  ngOnInit(): void {

    this.tercero = new Tercero();
    this.tercero.terceroID = 0;
    this.tercero.nombreTercero = "";
    this.tercero.direccion = "";
    this.tercero.telefono = "";
    this.tercero.pais = "";
    this.tercero.departamento = "";
    this.tercero.ciudad = "";

    this.registrarTerceroForm =  this.formBuilder.group(
      {
        inputDocumento : [this.tercero.terceroID,Validators.required],
        inputNombre : [this.tercero.nombreTercero,Validators.required],
        inputDireccion  : [this.tercero.direccion,Validators.required],
        inputTelefono : [this.tercero.telefono,Validators.required],
        inputPais : [this.tercero.pais,Validators.required],
        inputDepartamento : [this.tercero.departamento,Validators.required],
        inputCiudad : [this.tercero.ciudad,Validators.required]
      }
    );
  }

  get f() {return this.registrarTerceroForm.controls; };

  OnSubmit(){
    this.submitted = true;
    if(this.registrarTerceroForm.invalid)
    {
      return;
    }
    this.add();
  }

  add()
  {
    this.terceroService.post(this.tercero).subscribe((p) => {
      if(p != null)
      {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Proceso terminado";
        messageBox.componentInstance.message = "Exitoso";
        
      }
    });
  }

  onReset() {
    this.submitted = false;
    this.registrarTerceroForm.reset();
}
}
