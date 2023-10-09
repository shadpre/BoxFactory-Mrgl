import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: 'nav-bar.component.html',
  styleUrls: ['nav-bar.component.scss'],
})
export class NavBarComponent  implements OnInit {

  constructor() { }

  isMenuOpen: boolean = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  menuItemClicked(item: string) {
    // Handle the menu item click event here
    console.log(`Clicked on ${item}`);
    // You can implement specific actions for each menu item
  }
  ngOnInit() {}

}
