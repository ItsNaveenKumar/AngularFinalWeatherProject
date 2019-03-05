import { Component, OnInit } from '@angular/core';
import { WeatherService } from 'src/app/weather.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { NgModule } from '@angular/core';
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  constructor(private _weatherService: WeatherService,private httpClient:HttpClient ) {
    
  }
  markers:any=[];
markerss:any=[];
  lat;
  lon;

  enable = true;
  show = 1.0;

  forecastData:any=[];




  placeMarker($event){
    this.lat=$event.coords.lat;
    this.lon=$event.coords.lng;
   
    
    this._weatherService.getMarkers(this.lat,this.lon)
    .subscribe(
      data => { this.markers=[];
         this.markers.push(data); 
         this._weatherService.markersByCityName=this.markers;
         this._weatherService.date=new Date(this.markers[0].dt*1000);
         this._weatherService.time=this._weatherService.date.toLocaleTimeString() ;
        this._weatherService.day=this._weatherService.days[this._weatherService.date.getDay()];
      
      

      });

    
      
      
  }
  
  onInfoOpen(){

   
    if(this._weatherService.loginStatus=="Login"){
      this._weatherService.infoClose=false;
      this._weatherService.loginClose=true;
    }
    else{
      this._weatherService.getForeCast().subscribe(
        data =>{
          this.forecastData=[];
          // this.forecastData.push(data);
          console.log(data);
          this._weatherService.forecastData=data;
        }
      );
      this._weatherService.infoClose=true;
      
    }
  }

  ngOnInit(){ 
   
  }
  
  
  
  title = "Mausam";
  initMap = {
    lat: 26.696025,
    lng: 76.911220,
    zoom: 5,
    min_zoom: 2,
    max_zoom: 13,
  };

  dropdownSettings = {
    singleSelect: {
      singleSelection: true,
      closeDropDownOnSelection: true,
      idField: 'layer_option',
      textField: 'shape_name',
    }
  }


  weatherMapSource = "";
  weatherOption = {};
  weatherMapSourceApiKey = "9f4d67fc449f30b9c2a33a138be6b54e";
  mapWeatherLayers = [
    {shape_name:'Wind', layer_option:{layer_value:"wind_new",legendMin:"0 m/s",legendAvg:"100 m/s",legendMax:"200 m/s",legendTitle:"Wind Speed",scaleClass:"weather-wind"}},
    {shape_name:'Temperature',  layer_option:{layer_value:"temp_new",legendMin:"-40 deg C",legendAvg:"0 deg C",legendMax:"40 deg C",legendTitle:"Temperature",scaleClass:"weather-temperature"}},
     {shape_name:'Pressure', layer_option:{layer_value:"pressure_new",legendMin:"949.92 hPa",legendAvg:"1013.25 hPa",legendMax:"1070.63 hPa",legendTitle:"Pressure",scaleClass:"weather-pressure"}},
     {shape_name:'Percipitation', layer_option:{layer_value:"precipitation_new",legendMin:"0 mm",legendAvg:"100 mm",legendMax:"200 mm",legendTitle:"Snow",scaleClass:"weather-percepitation"}},
    {shape_name:'Clouds',  layer_option:{layer_value:"clouds_new",legendMin:"0 %",legendAvg:"50 %",legendMax:"100 %",legendTitle:"Cloud",scaleClass:"weather-cloud"}}
  ];
  selectedWeatherLayer = [];
  mapInstance:any;
  addWeatherLayer(){
    this.weatherMapSource = "https://tile.openweathermap.org/map/"+this.selectedWeatherLayer[0]["layer_option"]["layer_value"]+"/";
    this.weatherOption = this.selectedWeatherLayer[0]["layer_option"]
    this.plotWeatherLayers(this.mapInstance);
  }
  removeWeatherLayer(){
    this.weatherMapSource = "";
    this.mapInstance.overlayMapTypes.clear();
  }
  doSomethingWithTheMapInstance(event){
    this.mapInstance = event;
   
  }
  plotWeatherLayers(event){
    let weatherMapProvider = this.weatherMapSource;
    let weatherApiKey = this.weatherMapSourceApiKey;
    event.overlayMapTypes.clear();
    event.overlayMapTypes.insertAt(0, new agmMapType({width: 256, height: 256, f: "px", b: "px"})); 
    function agmMapType(tileSize){
      this.tileSize = tileSize;
    }
    agmMapType.prototype.getTile = function(coord, zoom, ownerDocument) {
      var div = ownerDocument.createElement('div');
      div.style.width = this.tileSize.width + 'px';
      div.style.height = this.tileSize.height + 'px';
      div.style.fontSize = '10';
      div.style['background-image'] = 'url('+weatherMapProvider + zoom + "/" + coord.x + "/" + coord.y + ".png?appid="+weatherApiKey+')';
      return div;
    };
  } 

onMouseOver(infoWindow, gm) {
     
   if (gm.lastOpen != null ) {
       gm.lastOpen.close();
   }

   gm.lastOpen = infoWindow;

   infoWindow.open();
   
   
}

}
