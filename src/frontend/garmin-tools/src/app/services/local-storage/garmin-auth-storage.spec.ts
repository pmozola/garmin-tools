import { TestBed } from '@angular/core/testing';

import { GarminAuthStorage } from './garmin-auth-storage';

describe('GarminAuthStorage', () => {
  let service: GarminAuthStorage;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GarminAuthStorage);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
