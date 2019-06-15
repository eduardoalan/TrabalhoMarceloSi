import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ImobiliariaComponent } from './Cadastro/imobiliaria/imobiliaria.component';
import { ImovelComponent } from './Cadastro/imovel/imovel.component';

const routes: Routes = [
  {path:'imobiliarias', component: ImobiliariaComponent},
  {path:'imovels', component: ImovelComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
