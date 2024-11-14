import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem, PrimeIcons } from 'primeng/api';

@Component({
  selector: 'app-menu-principal',
  templateUrl: './menu-principal.component.html',
  styleUrl: './menu-principal.component.css'
})
export class MenuPrincipalComponent {

  constructor(private rotas: Router){}

  mnu: MenuItem[];

  ngOnInit() 
  { 

    this.mnu = [ 
      {
        label: 'Home',
        icon: PrimeIcons.HOME,
        routerLink: ['/home']
      },
      {
        label: 'Trechos',
        routerLink: ['/trechos']
      }
    ]; 
  } 

}
