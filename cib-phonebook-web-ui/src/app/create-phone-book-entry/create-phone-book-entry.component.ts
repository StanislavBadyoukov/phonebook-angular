import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PhoneDirectoryService } from '../../services/phone-directory.service'
import { PhonebookEntry } from '../../models/phone-book-entry'

@Component({
  selector: 'app-create-phone-book-entry',
  templateUrl: './create-phone-book-entry.component.html',
  styleUrls: ['./create-phone-book-entry.component.css']
})
export class CreatePhoneBookEntryComponent implements OnInit {
  createForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private phoneDirectoryService: PhoneDirectoryService) { }

  ngOnInit() {    
    this.createForm = this.formBuilder.group({
      name: '',
      number: ''
    });
  }

  onSubmit(entryData) {
    let newEntry = {
      name: entryData.name,
      phoneNumber: entryData.number
    };
    this.phoneDirectoryService.savePhonebookEntry(newEntry);
    this.createForm.reset();
  }
}
