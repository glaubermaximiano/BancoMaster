import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './View/home/home.component';
import { TrechoComponent } from './View/trecho/trecho.component';
import { TrechoFormComponent } from './View/trecho-form/trecho-form.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'trechos', component: TrechoComponent},
  {path: 'novo-trecho', component: TrechoFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
