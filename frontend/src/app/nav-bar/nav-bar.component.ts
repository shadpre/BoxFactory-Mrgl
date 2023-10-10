import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: 'nav-bar.component.html',
  styleUrls: ['nav-bar.component.scss'],
})
export class NavBarComponent  implements OnInit {


  constructor() { }

  isMenuOpen: boolean = false;
  isContentHidden = true

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }


  menuItemClicked(item: string) {
    if (item === 'Item 1') {
      this.isContentHidden = false;
    } else if (item === 'Item 2') {
      this.isContentHidden = true;
    }
  }
  ngOnInit() {}

}

