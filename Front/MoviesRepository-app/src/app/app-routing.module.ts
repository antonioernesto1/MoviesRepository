import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmeComponent } from './pages/filme/filme.component';
import { HomeComponent } from './pages/home/home.component';
import { PesquisaComponent } from './pages/pesquisa/pesquisa.component';
import { SerieComponent } from './pages/serie/serie.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'filme/:id', component: FilmeComponent },
  { path: 'serie/:id', component: SerieComponent},
  { path: 'pesquisa', component: PesquisaComponent },
  { path: 'filme/pesquisa', component: PesquisaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
