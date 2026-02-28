import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { GarminAuth } from '../../../models/garmin-auth';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class GarminAuthApi {
   private httpClient = inject(HttpClient);
  verifyCredentials(auth:GarminAuth): Observable<GarminCredentialsResponse> {
    return this.httpClient.post<GarminCredentialsResponse>('garmin/credentials', auth );
  }
}

export interface GarminCredentialsResponse {
  isValid: boolean;
  errorMessage: string;
}

