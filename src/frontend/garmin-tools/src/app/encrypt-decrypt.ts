import { Injectable } from '@angular/core';
import * as Forge from 'node-forge';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EncryptDecrypt {
  encryptWithPublicKey(valueToEncrypt: string): string {
    const rsa = Forge.pki.publicKeyFromPem(environment.cryptographyKey);
    return window.btoa(rsa.encrypt(valueToEncrypt.toString()));
  }
}