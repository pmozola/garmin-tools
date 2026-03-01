import { Component, inject, Input } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { HttpLoadingService } from '../../services/loading/http-loading-service';
import { RouteConfigLoadEnd, RouteConfigLoadStart, Router } from '@angular/router';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-loading-indicator',
  imports: [ MatProgressSpinnerModule, AsyncPipe],
  templateUrl: './loading-indicator.html',
  styleUrl: './loading-indicator.css',
})
export class LoadingIndicator {
  loading$: Observable<boolean>;
  router: Router = inject(Router);

 @Input()
  detectRouteTransitions = false;

  constructor(private loaderService: HttpLoadingService) {
    this.loading$ = this.loaderService.loading$;
  }

ngOnInit() {
    if (this.detectRouteTransitions) {
      this.router.events
        .pipe(
          tap((event) => {
            console.log('Router event:', event);
            if (event instanceof RouteConfigLoadStart) {
              this.loaderService.loadingOn();
            } else if (event instanceof RouteConfigLoadEnd) {
              this.loaderService.loadingOff();
            }
          }),
          catchError((error) => {
            console.error('Error during route loading:', error);
            this.loaderService.loadingOff();
            return of(null);
          }
        ))
        .subscribe();
    }
}
}
