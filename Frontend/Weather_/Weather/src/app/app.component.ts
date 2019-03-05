import { Component,OnInit } from '@angular/core';
import { WeatherService } from 'src/app/weather.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { NgModule } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  
  constructor(private _weatherService: WeatherService,private httpClient:HttpClient ) {
    
  }


  ngOnInit(){ 
   
  }
  
}