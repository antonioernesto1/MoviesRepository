import { Component, Input, OnInit } from '@angular/core';
import { Ator } from 'src/app/models/ator';
import { faPlay } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-card-ator',
  templateUrl: './card-ator.component.html',
  styleUrls: ['./card-ator.component.css'],
})
export class CardAtorComponent implements OnInit {
  constructor() {}
  @Input() ator!: Ator;
  ngOnInit(): void {}
  faPlay = faPlay;
}
