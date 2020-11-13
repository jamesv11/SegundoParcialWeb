import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private modalService: NgbModal,public activeModal: NgbActiveModal,private terceroService : TerceroService ) { }

  @Input() Identificacion : string;

  tercero : Tercero = new Tercero();

  ngOnInit(): void {
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
}
