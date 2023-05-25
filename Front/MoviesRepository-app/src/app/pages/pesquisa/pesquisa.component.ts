import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Route, Router, RouterEvent } from '@angular/router';
import { filter } from 'rxjs';
import { Filme } from 'src/app/models/filme';
import { Serie } from 'src/app/models/serie';
import { FilmeService } from 'src/app/services/filme-service.service';
import { SerieService } from 'src/app/services/serie-service.service';


@Component({
  selector: 'app-pesquisa',
  templateUrl: './pesquisa.component.html',
  styleUrls: ['./pesquisa.component.css']
})
export class PesquisaComponent implements OnInit {

  constructor(private route: ActivatedRoute, private filmeService: FilmeService,
    private serieService: SerieService, private router: Router) { }
  nome: string = '';
  filmes!: Filme[];
  series!: Serie[];
  ngOnInit(): void {
    this.route.queryParams.subscribe(params =>{
      this.nome = params['nome'];
      console.log(this.nome);
    });
    this.getFilmes(this.nome);
    this.getSeries(this.nome);
  }
  getFilmes(nome: string){
      this.filmeService.getFilmesPorNome(nome).subscribe(filmes => {
        this.filmes = filmes;
        console.log(this.filmes);
      })
  }
  getSeries(nome: string){
    this.serieService.getSeriesPorNome(nome).subscribe(series => {
      this.series = series;
      console.log(this.series);
    })
  }

}
