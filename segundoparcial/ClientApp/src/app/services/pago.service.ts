import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Pago } from '../tercero/models/pago';
import { catchError,map,tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PagoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }
    get(): Observable<Pago[]>{
      return this.http.get<Pago[]>(this.baseUrl + 'api/Pago')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Pago[]>('Consulta Cliente',null))  
      );
    }
    post(pago: Pago): Observable<Pago>{
      return this.http.post<Pago>(this.baseUrl + 'api/Pago',pago).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Pago>('Registrar Cliente',null))
        );

    }
}
