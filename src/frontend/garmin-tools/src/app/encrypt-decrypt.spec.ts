import { TestBed } from '@angular/core/testing';

import { EncryptDecrypt } from './encrypt-decrypt';

describe('EncryptDecrypt', () => {
  let service: EncryptDecrypt;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EncryptDecrypt);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
