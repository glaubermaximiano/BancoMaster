import { Injectable } from '@angular/core';
import Swall, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertasService {

  constructor() { }

  public MsgErro(msg: string): void {
    this.MostraMsg("Oops...", msg, 'error');
  }

  private MostraMsg(titulo?: string, msg?: string,icone?: SweetAlertIcon): void 
  {
    Swall.fire(titulo, msg, icone);
  }
}
