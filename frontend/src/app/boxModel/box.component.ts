import {Component} from "@angular/core";
import {FormBuilder, Validators} from "@angular/forms";
import {ModalController, ToastController} from "@ionic/angular";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {State} from "../../state";
import {Box, ResponseDto} from "../../models";
import {environment} from "../../environments/environment";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-box-model',
  templateUrl: 'box.component.html',
  styleUrls: ['box.component.scss'],
})
export class CreateBoxComponent {

  createNewBoxForm = this.fb.group({
    boxName: ['', [Validators.minLength(4), Validators.required]],
    description: ['', [Validators.maxLength(500), Validators.required]],
    length: ['', Validators.required],
    width: ['', Validators.required],
    height: ['', Validators.required],
    price: ['', Validators.required]
  })

  constructor(public fb: FormBuilder, public modalController: ModalController, public http: HttpClient, public state: State, public toastController: ToastController) {
  }

  async submit() {

    try {
      const observable = this.http.post<ResponseDto<Box>>(environment.baseUrl + '/api/box', this.createNewBoxForm.getRawValue())

      const response = await firstValueFrom(observable);
      this.state.boxes.push(response.responseData!);

      const toast = await this.toastController.create({
        message: 'the box was successfully create',
        duration: 1233,
        color: "success"
      })
      toast.present();
      this.modalController.dismiss();
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

  cancel() {
    this.modalController.dismiss();
  }
}
