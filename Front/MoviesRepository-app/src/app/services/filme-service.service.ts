import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Filme } from 'src/app/models/filme';

@Injectable({
  providedIn: 'root',
})
export class FilmeService {
  private apiUrl: string =
    'https://localhost:7221/api/Filmes?includeAtores=false';
  constructor(private http: HttpClient) {}

  public getAllFilmes(): Observable<Filme[]> {
    return this.http.get<Filme[]>(this.apiUrl);
  }
}
