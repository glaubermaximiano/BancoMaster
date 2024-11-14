import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export abstract class AppConfig {

    public GetUrlApi(){
       return "https://localhost:44309/";
    }
 }