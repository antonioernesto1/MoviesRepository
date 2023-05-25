import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Serie } from 'src/app/models/serie';
import { SerieService } from 'src/app/services/serie-service.service';

@Component({
  selector: 'app-serie',
  templateUrl: './serie.component.html',
  styleUrls: ['./serie.component.css']
})
export class SerieComponent implements OnInit {
  serie: Serie = {
    nome: '',
    id: 0,
    trailerUrl: '',
    capaUrl: '',
    trailerEmbedUrl: '',
    anoLancamento: 0,
    categorias: [],
    sinopse: '',
  };
  url!: string;
  constructor(
    private serieService: SerieService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getSerie();
  }

  getSerie(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.serieService.getSerieById(id).subscribe((serie) => {
      this.serie = serie;
      this.url = serie.trailerUrl;
    });
  }

}
