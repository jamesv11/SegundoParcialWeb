import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Tercero } from '../tercero/models/tercero';

@Injectable({
  providedIn: 'root'
})
export class TerceroService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

    get(): Observable<Tercero[]>{
      return this.http.get<Tercero[]>(this.baseUrl + 'api/Tercero')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Tercero[]>('Consulta Cliente',null))  
      );
    }
    post(tercero: Tercero): Observable<Tercero>{
      console.log(tercero);
      return this.http.post<Tercero>(this.baseUrl + 'api/Tercero',tercero).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Tercero>('Registrar Cliente',null))
        );

    }
}
