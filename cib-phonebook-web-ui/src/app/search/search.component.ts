import { Component, OnInit } from '@angular/core';
import { PhonebookEntry } from '../../models/phone-book-entry';
import { PhoneDirectoryService } from '../../services/phone-directory.service'

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public foundEntries: PhonebookEntry[];
  constructor(private phoneDirectoryService: PhoneDirectoryService) { }

  ngOnInit() {
  }

  searchTextChanged(e){
    if(e.target.value.length < 3)
      return;

      this.foundEntries = [];
      
      this.phoneDirectoryService.getPhoneBookEntries(e.target.value).subscribe(result =>
        {
          this.foundEntries = result;
        });

      e.target.value = '';
  }
}
