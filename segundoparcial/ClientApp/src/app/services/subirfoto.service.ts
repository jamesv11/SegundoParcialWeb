import { HttpClient } from '@angular/common/http';
import { EventEmitter, Inject, Injectable, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { ImagenTercero } from '../tercero/models/imagenTercero';


@Injectable({
  providedIn: 'root'
})
export class SubirfotoService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

      /*
    post(formData : FormData):Observable<any>
    {
      return this.http.post<any>(this.baseUrl + '/api/Upload/UploadByte',formData).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<any>('Registrar foto',null))
      );
    }
    */
    post(imagenTercero : ImagenTercero): Observable<any>
    {
      console.log(imagenTercero);
      const fd =  new FormData();
      fd.append('image',imagenTercero.imagen,imagenTercero.imagen.name);

      console.log(fd.get.name);
      return this.http.post(this.baseUrl + 'api/SubirFoto',fd).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError('Foto registrada',null))
        );
    }
}
