import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Simulacao } from './model/simulacao';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class SimulacaoService {

  private url: string = 'http://localhost:5000/api/simulacao';

  constructor(private http: HttpClient) { }

  public addAsync(simulacao: Simulacao): Promise<Response> {
    return this.http.post<Response>(this.url, simulacao)
                          .toPromise();
  }

  public getAllAsync(): Observable<Simulacao[]> {
    return this.http.get<Simulacao[]>(this.url);
  }
}
