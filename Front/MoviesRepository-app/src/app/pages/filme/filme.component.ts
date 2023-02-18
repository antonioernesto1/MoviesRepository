import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme-service.service';

@Component({
  selector: 'app-filme',
  templateUrl: './filme.component.html',
  styleUrls: ['./filme.component.css'],
})
export class FilmeComponent implements OnInit {
  filme: Filme = {
    nome: '',
    id: 0,
    trailerUrl: '',
    capaUrl: '',
    trailerEmbedUrl: '',
    posterUrl: '',
    duracao: '',
    anoLancamento: 0,
    categorias: [],
    sinopse: '',
  };
  url!: string;
  constructor(
    private filmeService: FilmeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getFilme();
  }

  getFilme(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.filmeService.getFilmeById(id).subscribe((filme) => {
      this.filme = filme;
      console.log(filme.nome);
      this.url = filme.trailerUrl;
      console.log(filme.trailerEmbedUrl);
      filme.categorias.forEach((categoria) => {
        console.log(categoria.nome);
      });
      console.log(filme.sinopse);
    });
  }
}
