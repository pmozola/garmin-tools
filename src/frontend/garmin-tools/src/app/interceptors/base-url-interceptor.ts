import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { API_URL } from '../core/api-token';

export const baseUrlInterceptor: HttpInterceptorFn = (req, next) => {
  const apiUrl = inject(API_URL);

  if (!req.url.startsWith('http')) {
    req = req.clone({ url: apiUrl + req.url });
  }

  return next(req);
};
