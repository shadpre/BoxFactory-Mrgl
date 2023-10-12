import {Component, OnInit } from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import { State } from 'src/state';
import {Box} from 'src/models';
import { environment } from 'src/environments/environment';
import {ModalController, ToastController} from "@ionic/angular";
import {UpdateBoxComponent} from "../boxUpdate/boxUpdate.component";
import {CreateBoxComponent} from "../boxCreate/boxCreate.component";

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

    const result = await firstValueFrom(this.http.get<Box[]>(environment.baseUrl + '/api/box'))
    this.state.boxes = result!;
  }

  ngOnInit(): void {
    this.fetchBoxes()
  }


  async deleteBox(boxId: number | undefined) {
    try {
      await firstValueFrom(this.http.delete(environment.baseUrl + '/api/box/'+ boxId))
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

  async openCreateModal() {
    const modal = await this.modalController.create({
      component: CreateBoxComponent
    });
    await modal.present();
  }

  async openUpdateModal(box: Box) {
    this.state.editBox = box;
    const modal = await this.modalController.create({
      component: UpdateBoxComponent,
      componentProps: {

      },
    });
    await modal.present();
  }
}
