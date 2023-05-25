import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Serie } from '../models/serie';

@Injectable({
  providedIn: 'root',
})
export class SerieService {
  constructor(private http: HttpClient) {}
  private apiUrl: string = 'https://localhost:7221/api/Series';

  public getAllSeries(): Observable<Serie[]> {
    return this.http.get<Serie[]>(this.apiUrl);
  }
  public getSerieById(id: number): Observable<Serie>{
    return this.http.get<Serie>(`${this.apiUrl}/${id}`)
  }
  public getSeriesPopulares(): Observable<Serie[]>{
    return this.http.get<Serie[]>(`${this.apiUrl}/lancamentos`)
  }
  public getSeriesPorNome(nome: string):Observable<Serie[]>{
    const params = new HttpParams()
      .set('nome', nome);
    return this.http.get<Serie[]>(`${this.apiUrl}/por-nome`, {params})
  }
}
