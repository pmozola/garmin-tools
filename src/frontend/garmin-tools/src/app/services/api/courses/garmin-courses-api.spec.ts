import { TestBed } from '@angular/core/testing';

import { GarminCoursesApi } from './garmin-courses-api';

describe('GarminCoursesApi', () => {
  let service: GarminCoursesApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GarminCoursesApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
