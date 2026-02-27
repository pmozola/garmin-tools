import { Injectable } from '@angular/core';
import { LocalStorage } from './local-storage';
import { GarminAuth } from '../../models/garmin-auth';

@Injectable({
  providedIn: 'root',
})
export class GarminAuthStorage {
  constructor(private readonly localStorage:LocalStorage){}

  private readonly storageKey:string = "garminAuth"

  setAuth(email:string, password:string): void {
    const auth: GarminAuth = { email, password };
    this.localStorage.setItem(this.storageKey, auth);
  }

  getAuth(): GarminAuth | null {
    return this.localStorage.getItem(this.storageKey);
  }
}
