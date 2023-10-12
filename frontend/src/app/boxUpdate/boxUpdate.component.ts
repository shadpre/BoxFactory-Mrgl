import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, Validators} from '@angular/forms';
import { ModalController, ToastController } from '@ionic/angular';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { State } from '../../state';
import { Box, ResponseDto } from '../../models';
import { environment } from '../../environments/environment';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-box-Update',
  templateUrl: 'boxUpdate.component.html',
  styleUrls: ['boxUpdate.component.html'],
})
export class UpdateBoxComponent  {

  updateBoxForm = this.fb.group({
    boxName: ['', [Validators.minLength(4), Validators.required]],
    description:['', [Validators.maxLength(500), Validators.required]],
    length: [0, Validators.required],
    width:[0, Validators.required],
    height:[0, Validators.required],
    price:[0, Validators.required]
  });


  constructor(
    public fb: FormBuilder,
    public modalController: ModalController,
    public http: HttpClient,
    public state: State,
    public toastController: ToastController

  ) {
console.log(this.state.editBox)
    this.updateBoxForm.patchValue({
      boxName: this.state.editBox.boxName,
      description: this.state.editBox.description,
      length: this.state.editBox.length,
      width: this.state.editBox.width,
      height: this.state.editBox.height,
      price: this.state.editBox.price
    });
  }


  async updateBox() {
    try {
      const boxId = this.state.editBox.boxId; // Get the ID of the box to update
      const observable = this.http.put<ResponseDto<Box>>(
        environment.baseUrl + '/api/box', {...this.updateBoxForm.getRawValue(), boxId: this.state.editBox.boxId}
      );

      const response = await firstValueFrom(observable);

      // Find the index of the updated box in the state and replace it with the updated data
      const index = this.state.boxes.findIndex((box) => box.boxId === boxId);
      this.state.boxes[index] = response.responseData!;

      const toast = await this.toastController.create({
        message: 'The box was successfully updated',
        duration: 1233,
        color: 'success',
      });
      toast.present();
      this.modalController.dismiss();
    } catch (e) {
      console.log(e);
      if (e instanceof HttpErrorResponse) {
        const toast = await this.toastController.create({
          //message: e.error.messageToClient,
          duration: 1233,
          color: 'danger',
        });
        toast.present();
      }
    }
  }

  cancel() {
    this.modalController.dismiss();
  }
}
