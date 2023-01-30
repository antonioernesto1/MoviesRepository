import { Component, OnInit, Input } from '@angular/core';
import { faPlay } from '@fortawesome/free-solid-svg-icons';
import { Filme } from 'src/app/models/filme';

@Component({
  selector: 'app-card-filme',
  templateUrl: './card-filme.component.html',
  styleUrls: ['./card-filme.component.css'],
})
export class CardFilmeComponent implements OnInit {
  constructor() {}
  @Input() filme!: Filme;

  ngOnInit(): void {}
  faPlay = faPlay;
}
