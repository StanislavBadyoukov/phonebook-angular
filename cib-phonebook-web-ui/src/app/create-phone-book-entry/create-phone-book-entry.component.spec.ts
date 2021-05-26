import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePhoneBookEntryComponent } from './create-phone-book-entry.component';

describe('CreatePhoneBookEntryComponent', () => {
  let component: CreatePhoneBookEntryComponent;
  let fixture: ComponentFixture<CreatePhoneBookEntryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatePhoneBookEntryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePhoneBookEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
