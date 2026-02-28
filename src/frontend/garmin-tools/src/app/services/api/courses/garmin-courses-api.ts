import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GarminAuthStorage } from '../../local-storage/garmin/garmin-auth-storage';

@Injectable({
  providedIn: 'root',
})

export class GarminCoursesApi {
  private httpClient = inject(HttpClient);
  private localstorage = inject(GarminAuthStorage);

  getAll(): Observable<GetAllCoursesQueryResponse[]> {
    const auth = this.localstorage.getAuth()!;

    return this.httpClient.get<GetAllCoursesQueryResponse[]>('garmin/courses', { params: { email: auth.email, password: auth.password } });
  }
}

export interface GetAllCoursesQueryResponse {
  name: string;
  id: number;
}