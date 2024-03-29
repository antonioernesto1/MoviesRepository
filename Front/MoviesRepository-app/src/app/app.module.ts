import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './pages/home/home.component';
import { CardFilmeComponent } from './components/card-filme/card-filme.component';
import { CardSerieComponent } from './components/card-serie/card-serie.component';
import { CardAtorComponent } from './components/card-ator/card-ator.component';
import { FilmeComponent } from './pages/filme/filme.component';
import { SafePipe } from './helpers/safe.pipe';
import { PesquisaComponent } from './pages/pesquisa/pesquisa.component';
import { SerieComponent } from './pages/serie/serie.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    CardFilmeComponent,
    CardSerieComponent,
    CardAtorComponent,
    FilmeComponent,
    SafePipe,
    PesquisaComponent,
    SerieComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
