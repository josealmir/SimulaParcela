import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Simulacao } from './simulacao';

@Injectable({
  providedIn: 'root'
})
export class SimulacaoService {

  constructor(private http: HttpClient,
    public url: string) { }

  public async addAsync(simulacao: Simulacao): Promise<Response> {
    return await this.http.post<Response>(this.url, simulacao)
                          .toPromise() as Response;
  }
}
