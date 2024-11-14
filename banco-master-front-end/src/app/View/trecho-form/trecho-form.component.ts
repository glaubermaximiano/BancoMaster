import { Component } from '@angular/core';
import { TrechoRequest } from '../../models/trecho-request';
import { Router } from '@angular/router';
import { AlertasService } from '../../services/alertas.service';
import { RotaService } from '../../services/rota.service';

@Component({
  selector: 'app-trecho-form',
  templateUrl: './trecho-form.component.html',
  styleUrl: './trecho-form.component.css'
})
export class TrechoFormComponent {

  public _model: TrechoRequest

  constructor(private rotas: Router,
              private alertaService: AlertasService,
              private rotaService: RotaService) { }

  ngOnInit(): void {
    this._model = new TrechoRequest(); 
  }

  public OnClickSalvar(): void
  {
    console.log(this._model)

    this.rotaService.Add(this._model).subscribe(
      (data) => 
      {  
        this.rotas.navigate(['trechos']);
      },
      (httpErro) => {
        this.alertaService.MsgErro(httpErro.error);
      }
    );
  }

}
