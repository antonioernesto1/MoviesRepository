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
  filmes: Filme[] = [];
  series: Serie[] = [];
  ngOnInit(): void {
    this.getAllFilmes();
    this.getAllSeries();
  }

  getAllFilmes() {
    this.filmeService.getAllFilmes().subscribe((filmes) => {
      this.filmes = filmes;
      console.log(this.filmes[0]);
    });
  }
  getAllSeries() {
    this.serieService.getAllSeries().subscribe((series) => {
      this.series = series;
      console.log(this.series[0]);
    });
  }
}
