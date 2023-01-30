import { Component, OnInit } from '@angular/core';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private filmeService: FilmeService) {}
  filmes: Filme[] = [];
  ngOnInit(): void {
    this.getAllTarefas();
  }

  getAllTarefas() {
    this.filmeService.getAllFilmes().subscribe((filmes) => {
      this.filmes = filmes;
      console.log(this.filmes[0]);
    });
  }
}
