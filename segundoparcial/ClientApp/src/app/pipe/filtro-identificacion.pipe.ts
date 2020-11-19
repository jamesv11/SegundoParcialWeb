import { Pipe, PipeTransform } from '@angular/core';
import { Pago } from '../tercero/models/pago';

@Pipe({
  name: 'filtroIdentificacion'
})
export class FiltroIdentificacionPipe implements PipeTransform {

  transform(pagos: Pago[], searchText: string): any {
    if (searchText == null) return Pago;
         return pagos.filter(p=>
          p.terceroIdentificacion.toLowerCase()
          .indexOf(searchText.toLowerCase()) !== -1);
      }
    

}
