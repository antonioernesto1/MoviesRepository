import { Component, Input, OnInit } from '@angular/core';
import { faPlay } from '@fortawesome/free-solid-svg-icons';
import { Serie } from 'src/app/models/serie';
@Component({
  selector: 'app-card-serie',
  templateUrl: './card-serie.component.html',
  styleUrls: ['./card-serie.component.css'],
})
export class CardSerieComponent implements OnInit {
  @Input() serie!: Serie;
  constructor() {}

  ngOnInit(): void {}
  faPlay = faPlay;
}
