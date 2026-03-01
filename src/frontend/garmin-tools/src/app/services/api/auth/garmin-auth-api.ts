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
    return this.httpClient.post<GarminCredentialsResponse>(GarminApiUrls.verifyCredentials, auth );
  }
}

export interface GarminCredentialsResponse {
  isValid: boolean;
  errorMessage: string;
}

export class GarminApiUrls {
  public static prefix: string  ='garmin';
  public static verifyCredentials = `${GarminApiUrls.prefix}/credentials`;
}


