import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import { State } from 'src/state';
import {Box, ResponseDto } from 'src/models';
import { environment } from 'src/environments/environment';
import {ModalController, ToastController} from "@ionic/angular";
import {CreateBoxComponent} from "../boxModel/box.component";

@Component({
  selector: 'app-card',
  templateUrl: 'card.component.html',
  styleUrls: ['card.component.scss'],
})

export class CardComponent implements OnInit {

  constructor(public http: HttpClient,public modalController: ModalController,
              public state: State, public toastController: ToastController) {

  }


  async fetchBoxes() {

    const result = await firstValueFrom(this.http.get<ResponseDto<Box[]>>(environment.baseUrl + '/api/box'))
    this.state.boxes = result.responseData!;
  }

  ngOnInit(): void {
    this.fetchBoxes()
  }


  async deleteBox(boxId: number | undefined) {
    try {
      await firstValueFrom(this.http.delete(environment.baseUrl + '/api/box/'+boxId))
      this.state.boxes = this.state.boxes.filter(b => b.boxId != boxId)
      const toast = await this.toastController.create({
        message: 'the box was successfully deleted',
        duration: 1233,
        color: "success"
      })
      toast.present();
    } catch (e) {
      console.log(e);
      if(e instanceof HttpErrorResponse) {
        const toast = await this.toastController.create({
          message: e.error.messageToClient,
          duration: 1233,
          color: "danger"
        });
        toast.present();
      }
    }

  }

  async openModal() {
    const modal = await this.modalController.create({
      component: CreateBoxComponent
    });
    modal.present();
  }
}
