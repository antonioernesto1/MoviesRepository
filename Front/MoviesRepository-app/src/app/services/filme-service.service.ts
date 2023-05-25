import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Filme } from 'src/app/models/filme';

@Injectable({
  providedIn: 'root',
})
export class FilmeService {
  private apiUrl: string = 'https://localhost:7221/api/Filmes';
  constructor(private http: HttpClient) {}

  public getAllFilmes(): Observable<Filme[]> {
    return this.http.get<Filme[]>(this.apiUrl);
  }
  public getLancamentos(): Observable<Filme[]>{
    return this.http.get<Filme[]>(`${this.apiUrl}/lancamentos`)
  }
  public getPopulares(): Observable<Filme[]>{
    return this.http.get<Filme[]>(`${this.apiUrl}/populares`)
  }
  public getFilmeById(id: number): Observable<Filme> {
    return this.http.get<Filme>(`${this.apiUrl}/${id}`);
  }
  public getFilmesPorNome(nome: string):Observable<Filme[]>{
    const params = new HttpParams()
      .set('nome', nome);
    return this.http.get<Filme[]>(`${this.apiUrl}/por-nome`, {params})
  }
}
