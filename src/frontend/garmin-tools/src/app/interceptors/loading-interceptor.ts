import { HttpContextToken, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { HttpLoadingService } from '../services/loading/http-loading-service';
import { finalize } from 'rxjs';

export const SkipLoading = new HttpContextToken<boolean>(() => false);

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
    const loadingService = inject(HttpLoadingService);

    if (req.context.get(SkipLoading)) {
      return next(req);
    }

    loadingService.loadingOn();

    return next(req).pipe(
      finalize(() => {
        loadingService.loadingOff();
      })
    );


  return next(req);
};

// https://blog.angular-university.io/angular-loading-indicator/