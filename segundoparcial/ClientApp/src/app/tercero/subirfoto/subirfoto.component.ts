import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SubirfotoService } from 'src/app/services/subirfoto.service';
import { ImagenTercero } from '../models/imagenTercero';

@Component({
  selector: 'app-subirfoto',
  templateUrl: './subirfoto.component.html',
  styleUrls: ['./subirfoto.component.css']
})
export class SubirfotoComponent implements OnInit {

  imagenTercero : ImagenTercero;
  selectedFile : string | ArrayBuffer;

  
  constructor(private subirfotoService : SubirfotoService) { }

  ngOnInit(): void {
    this.imagenTercero =  new ImagenTercero();
  }

  
  onPhotoSelected(event: { target: { files: File[]; }; }): void{
    console.log(event);
    if(event.target.files && event.target.files[0]){

      this.imagenTercero.imagen = <File>event.target.files[0];
      const reader = new FileReader();
      reader.onload =  e => this.selectedFile = reader.result;
      reader.readAsDataURL(this.imagenTercero.imagen);

    }
    console.log(this.selectedFile);
    console.log(this.imagenTercero.imagen);
    
  }

  uploadPhoto() : boolean
  {
    this.subirfotoService.post(this.imagenTercero).subscribe(res => console.log(res), err => console.log(err));
    return false;
  }
  
}
