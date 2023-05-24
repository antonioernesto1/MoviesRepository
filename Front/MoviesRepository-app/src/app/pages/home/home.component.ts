import { Component, OnInit } from '@angular/core';
import { Filme } from 'src/app/models/filme';
import { Serie } from 'src/app/models/serie';
import { FilmeService } from 'src/app/services/filme-service.service';
import { SerieService } from 'src/app/services/serie-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(
    private filmeService: FilmeService,
    private serieService: SerieService
  ) {}
  filmes_lancamentos: Filme[] = [];
  filmes_populares: Filme[] = [];
  series: Serie[] = [];
  ngOnInit(): void {
    this.getFilmesLancamentos();
    this.getFilmesPopulares();
    this.getAllSeries();
  }

  getFilmesLancamentos() {
    this.filmeService.getLancamentos().subscribe((filmes) => {
      this.filmes_lancamentos = filmes;
      console.log(filmes);
    });
  }
  getFilmesPopulares() {
    this.filmeService.getPopulares().subscribe((filmes) => {
      this.filmes_populares = filmes;
      console.log(filmes);
    });
  }
  getAllSeries() {
    this.serieService.getAllSeries().subscribe((series) => {
      this.series = series;
      console.log(this.series[0]);
    });
  }
}
