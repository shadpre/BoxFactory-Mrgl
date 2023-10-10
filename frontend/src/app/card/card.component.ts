import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import { State } from 'src/state';
import {Box, ResponseDto } from 'src/models';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-card',
  templateUrl: 'card.component.html',
  styleUrls: ['card.component.scss'],
})

export class CardComponent implements OnInit {
  isAlertOpen = false;
  public alertButtons = ['Yes', 'No'];

  // ...

  handleAlertDismiss(result: any) {
    // Handle the alert dismissal here
    if (result.role === 'Yes') {
      // User clicked 'Yes'
      // Perform your delete action or any other action
    } else {
      // Close the alert
      this.isAlertOpen = false;
    }
  }

  // Call this method to open the alert
  openAlert() {
    this.isAlertOpen = true;
  }

  constructor(public http: HttpClient, public state: State) {}

  async fetchBoxes() {

    const result = await firstValueFrom(this.http.get<ResponseDto<Box[]>>(environment.baseUrl + '/'))
    this.state.boxes = result.responseData!;
  }

  ngOnInit(): void {
    this.fetchBoxes()
  }


}
