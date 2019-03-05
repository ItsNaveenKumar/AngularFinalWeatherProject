import { Component, OnInit } from '@angular/core';
import { WeatherService } from 'src/app/weather.service';

@Component({
  selector: 'app-weather-info',
  templateUrl: './weather-info.component.html',
  styleUrls: ['./weather-info.component.css']
})
export class WeatherInfoComponent implements OnInit {

  constructor(private _weatherService:WeatherService) { }
  locations;
  markers:any=[];
  obj;
  ngOnInit() {
    
  }
 onClose(){
   this._weatherService.infoClose=false;
 }
 onSave()
 { 
   this._weatherService.onSave().subscribe(data => {
    this.obj={
    userId:this._weatherService.userData.userId,
    savedLocationId: data.savedLocationId }
    console.log(this.obj);
    this._weatherService.onSaveLocation(this.obj).subscribe(val => console.log(val));
    });
   this._weatherService.getSavedLocation(this._weatherService.userData.userId).subscribe(data =>{
    this.locations=data;
   
    
  });

 
 }
 onSavedLocation(){
  this._weatherService.getSavedLocation(this._weatherService.userData.userId).subscribe(data =>{
    this.locations=data;
  });
 }
 onDelete(loc:HTMLInputElement,i){
   console.log(loc.id);
   this._weatherService.onDelete(loc.id).subscribe(val => console.log(val));
   this.locations.splice(i, 1);
 }
 onCity(cityName:HTMLInputElement){
   this._weatherService.onCity(cityName.id).subscribe(
    data => { this.markers=[];
       this.markers.push(data); 
       
       this._weatherService.markersByCityName=this.markers;});
 }
}
