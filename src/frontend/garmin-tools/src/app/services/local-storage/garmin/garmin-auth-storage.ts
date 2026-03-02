import { Injectable } from '@angular/core';
import { LocalStorage } from '../common/local-storage';
import { GarminAuth } from '../../../models/garmin-auth';
import { EncryptDecrypt } from '../../../encrypt-decrypt';

@Injectable({
  providedIn: 'root',
})
export class GarminAuthStorage {
  constructor(private readonly localStorage: LocalStorage, private readonly encryptDecrypt: EncryptDecrypt) { }

  private readonly storageKey: string = "garminAuth"

  setAuth(email: string, password: string): void {
    const securedEmail = this.encryptDecrypt.encryptWithPublicKey(email);
    const securedPassword = this.encryptDecrypt.encryptWithPublicKey(password);

    const auth: GarminAuth = { email: securedEmail, password: securedPassword };
    this.localStorage.setItem(this.storageKey, auth);
  }

  getAuth(): GarminAuth | null {
    return this.localStorage.getItem(this.storageKey);
  }
}
