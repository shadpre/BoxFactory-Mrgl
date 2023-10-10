import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { HomeComponent } from './home.component';
import {NavBarComponent} from './nav-bar/nav-bar.component';
import {CardComponent} from './card/card.component';
import {CreateBoxComponent} from "./boxModel/box.component";
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [HomeComponent, NavBarComponent, CardComponent, CreateBoxComponent],
  imports: [BrowserModule, IonicModule.forRoot({mode: "ios"}), AppRoutingModule, HttpClientModule, ReactiveFormsModule],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [HomeComponent],
})
export class AppModule {}
