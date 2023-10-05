import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import { State } from 'src/state';
import {Box, ResponseDto } from 'src/models';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-box-factory',
  templateUrl: 'box-factory.component.html',
  styleUrls: ['box-factory.component.scss'],
})
export class BoxFactoryComponent  implements OnInit {
  constructor(public http: HttpClient, public state: State) {}

  async fetchBoxes() {

    const result = await firstValueFrom(this.http.get<ResponseDto<Box[]>>(environment.baseUrl + '/'))
    this.state.boxes = result.responseData!;
  }

  ngOnInit(): void {
    this.fetchBoxes()
  }

}
