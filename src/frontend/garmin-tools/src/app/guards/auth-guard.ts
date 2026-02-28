import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { GarminAuthStorage } from '../services/local-storage/garmin/garmin-auth-storage';
import { inject } from '@angular/core';


export const authGuard: CanActivateFn = (): boolean | UrlTree => {
  const storage = inject(GarminAuthStorage);
  const router = inject(Router);
  
  return storage.getAuth() != null || router.createUrlTree(['/login']);
}