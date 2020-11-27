import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PagoRegistroComponent } from './tercero/pago-registro/pago-registro.component';
import { PagoConsultaComponent } from './tercero/pago-consulta/pago-consulta.component';
import { HomeComponent } from './home/home.component';
import { TerceroRegistroComponent } from './tercero/tercero-registro/tercero-registro.component';
import { SubirfotoComponent } from './tercero/subirfoto/subirfoto.component';
import { VistaFotoComponent } from './tercero/vista-foto/vista-foto.component';

const routes : Routes = [
  {
    path:'pagoRegistro',
    component: PagoRegistroComponent
  }
  ,
  {
    path:'pagoConsulta',
    component: PagoConsultaComponent
  }
  ,
  {
    path:'',
    component: HomeComponent
  }
  ,
  {
    path:'terceroRegistro',
    component: TerceroRegistroComponent
  }
  ,
  {
    path:'subirFoto',
    component: SubirfotoComponent
  }
  ,
  {
    path:'vistaFoto',
    component: VistaFotoComponent
  }

  

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
