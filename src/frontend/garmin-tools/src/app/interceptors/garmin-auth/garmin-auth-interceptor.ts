import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { GarminAuthStorage } from '../../services/local-storage/garmin/garmin-auth-storage';
import { GarminApiUrls } from '../../services/api/auth/garmin-auth-api';

const GARMIN_PASSWORD_HEADER = 'Garmin-Password';
const GARMIN_EMAIL_HEADER = 'Garmin-Email';

export const garminAuthInterceptor: HttpInterceptorFn = (req, next) => {
  if (!req.url.includes(GarminApiUrls.verifyCredentials) &&
    req.url.includes(`/${GarminApiUrls.prefix}`)) {

    let store = inject(GarminAuthStorage);
    const modified = req.clone({
      setHeaders: {
        [GARMIN_EMAIL_HEADER]: store.getAuth()?.email ?? '',
        [GARMIN_PASSWORD_HEADER]: store.getAuth()?.password ?? ''
      }
    });
    return next(modified);
  }

  return next(req);
};
