import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../environments/environment";
import {firstValueFrom} from "rxjs";
import {Box, ResponseDto} from "../models";
import {State} from "../state";

@Component({
  selector: 'app-root',
  templateUrl: 'home.component.html',
  styleUrls: ['home.component.scss'],
})
export class HomeComponent implements OnInit{
  constructor(public http: HttpClient, public state: State) {

  }

  async fetchBoxes() {

  }

  ngOnInit(): void {
  }
}
