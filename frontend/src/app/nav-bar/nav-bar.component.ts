import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { Box } from '../../models';
import { State } from '../../state';


@Component({
  selector: 'app-nav-bar',
  templateUrl: 'nav-bar.component.html',
  styleUrls: ['nav-bar.component.scss'],
})
export class NavBarComponent  implements OnInit {
  searchQuery: string = '';
  searchResults: Box[] = []; // Store search results here
  isMenuOpen: boolean = false;
  isContentHidden = true

  constructor(private http: HttpClient, public state: State) {}

  onSearch() {
    if (this.searchQuery) {
      // Implement your search logic here (e.g., call the fetchBoxes function)
      this.fetchBoxes(this.searchQuery);
    } else {
      this.searchResults = []; // Clear search results when the query is empty
    }
  }


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
  ngOnInit() {
    this.fetchBoxes();
  }

  async fetchBoxes(searchQuery?: string) {
    let url = `${environment.baseUrl}/api/box`;

    if (searchQuery) {
      // If a search query is provided, add it to the URL
      url += `?searchQuery=${searchQuery}`;
    }

    const result = await firstValueFrom(this.http.get<Box[]>(url));
    this.state.boxes = result!;
  }


}

