import {Injectable} from "@angular/core";
import {Box} from "./models";

@Injectable({
  providedIn: 'root'
})
export class State {
  boxes: Box[] =[
    {
      boxId: 1,
      boxName: 'Box A',
      description: "this a box",
      length: 10,
      width: 8,
      height: 6,
      price: 15.99,
      amount: 20
    },
    {
      boxId: 2,
      boxName: 'Box B',
      description: "this a box",
      length: 12,
      width: 9,
      height: 7,
      price: 19.99,
      amount: 15
    },
    {
      boxId: 3,
      boxName: 'Box C',
      description: "this a box",
      length: 8,
      width: 6,
      height: 4,
      price: 12.99,
      amount: 25
    },
    {
      boxId: 4,
      boxName: 'Box D',
      description: "this a box",
      length: 15,
      width: 10,
      height: 8,
      price: 24.99,
      amount: 18
    },
    {
      boxId: 5,
      boxName: 'Sample Box',
      description: 'This is a sample box description.',
      length: 10,
      width: 8,
      height: 6,
      price: 15.99,
      amount: 20,
    }
  ];
}
