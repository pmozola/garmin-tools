import { TestBed } from '@angular/core/testing';
import { GarminAuthApi } from './garmin-auth-api';

describe('GarminAuthApi', () => {
  let service: GarminAuthApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GarminAuthApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
