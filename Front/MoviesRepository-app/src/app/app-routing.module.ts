import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmeComponent } from './pages/filme/filme.component';
import { HomeComponent } from './pages/home/home.component';
import { PesquisaComponent } from './pages/pesquisa/pesquisa.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'filme/:id', component: FilmeComponent },
  { path: 'pesquisa', component: PesquisaComponent },
  { path: 'filme/pesquisa', component: PesquisaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
