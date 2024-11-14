import { Injectable } from '@angular/core';
import { AppConfig } from '../Config/app-config';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TrechoRequest } from '../models/trecho-request';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RotaService {

  _url = this.config.GetUrlApi();

  constructor(  private http: HttpClient,
                private config: AppConfig) { }

  public ListaTodos(): Observable<TrechoRequest[]>
  {
     return this.http.get<TrechoRequest[]>((this._url + 'api/BancoMaster/trechos'));
  }

  public BuscaRotaMaisBarata(origemDestino: string): Observable<TrechoRequest>
  {
     return this.http.get<TrechoRequest>((this._url + 'api/BancoMaster/rota-mais-barata/' + origemDestino));
  }

  public Add(obj: TrechoRequest): Observable<string>
  {
    return this.http.post((this._url + 'api/BancoMaster/trecho'),  obj, { responseType: 'text' } ).pipe( tap((token) => { 
      }) );
  }
}
