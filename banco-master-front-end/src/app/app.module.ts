import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CardModule } from 'primeng/card';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { CommonModule } from '@angular/common';
import { SplitButtonModule } from 'primeng/splitbutton';
import { TableModule } from 'primeng/table';
import { InputNumberModule } from 'primeng/inputnumber';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ContextMenuModule } from 'primeng/contextmenu';
import { ToolbarModule } from 'primeng/toolbar';
import { CheckboxModule } from 'primeng/checkbox';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { HomeComponent } from './View/home/home.component';
import { MenuPrincipalComponent } from './View/menu-principal/menu-principal.component';
import { TrechoComponent } from './View/trecho/trecho.component';
import { TrechoFormComponent } from './View/trecho-form/trecho-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuPrincipalComponent,
    TrechoComponent,
    TrechoFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CardModule,
    FormsModule,    
    InputTextModule,
    ButtonModule,    
    MenubarModule,
    ConfirmDialogModule,
    CommonModule,
    SplitButtonModule,
    TableModule,
    InputNumberModule,
    RadioButtonModule,
    ContextMenuModule,
    ToolbarModule,
    CheckboxModule,
    CalendarModule,
    SplitButtonModule,
    ContextMenuModule,
    DropdownModule,
    PanelModule,
    DialogModule,
    InputTextareaModule,
    ProgressSpinnerModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
