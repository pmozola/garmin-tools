import { TestBed } from '@angular/core/testing';

import { LocalStorage } from '../common/local-storage';

describe('LocalStorage', () => {
  let service: LocalStorage;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocalStorage);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
