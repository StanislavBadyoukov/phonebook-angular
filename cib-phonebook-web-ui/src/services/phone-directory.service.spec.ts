import { TestBed } from '@angular/core/testing';

import { PhoneDirectoryService } from './phone-directory.service';

describe('PhoneDirectoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhoneDirectoryService = TestBed.get(PhoneDirectoryService);
    expect(service).toBeTruthy();
  });
});
