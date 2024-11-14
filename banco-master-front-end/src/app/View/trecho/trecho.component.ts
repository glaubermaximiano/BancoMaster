import { Component, OnInit } from '@angular/core';
import { TrechoRequest } from '../../models/trecho-request';
import { RotaService } from '../../services/rota.service';
import { Router } from '@angular/router';
import { AlertasService } from '../../services/alertas.service';

@Component({
  selector: 'app-trecho',
  templateUrl: './trecho.component.html',
  styleUrl: './trecho.component.css'
})
export class TrechoComponent implements OnInit{

  public _lstTrechos: TrechoRequest[]
  public _idcCarregando: boolean = true

  constructor(private rotas: Router,
              private rotaService: RotaService) { }

  ngOnInit(): void {

    this._idcCarregando = true;

    this.rotaService.ListaTodos().subscribe( (data) => {  
       this._lstTrechos = data

       this._idcCarregando = false;
    });

  }

  public OnClickNovo():void
  {
    this.rotas.navigate(["/novo-trecho"]);
  }




}
