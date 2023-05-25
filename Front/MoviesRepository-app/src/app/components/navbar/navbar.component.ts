import { Component, OnInit } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {}
  pesquisa: string = '';
  faSearch = faSearch;

  async pesquisar()
  {
    const queryParams: any =  {
      nome: this.pesquisa
    }
    const navigationExtras: NavigationExtras = {
      queryParams: queryParams
    }
    var rota = this.router.url.split('?')[0];
    await this.router.navigate(["/pesquisa"], navigationExtras);
    if(rota == '/pesquisa'){
      location.reload();
    }
  }
}
