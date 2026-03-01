import { Component, inject, signal } from '@angular/core';
import { email, form, FormField, required } from '@angular/forms/signals';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { GarminAuthStorage } from '../../services/local-storage/garmin/garmin-auth-storage';
import { GarminAuth } from '../../models/garmin-auth';
import { Router } from '@angular/router';
import { GarminAuthApi } from '../../services/api/auth/garmin-auth-api';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrl: './login.css',
  imports: [
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    FormField
  ]
})
export class Login {
  private storage = inject(GarminAuthStorage);
  private api = inject(GarminAuthApi);
  private router = inject(Router);

  loginModel = signal<GarminAuth>({
    email: '',
    password: ''
  })

  addressForm = form(this.loginModel, (schemaPath) => {
    required(schemaPath.email, { message: 'Email is required' }),
      email(schemaPath.email, { message: 'Email is not valid' }),
      required(schemaPath.password, { message: 'Password is required' })
  });

  onSubmit(event: Event): void {
    event.preventDefault();

    if (this.addressForm().valid()) {
      this.api.verifyCredentials({
        email: this.addressForm.email().value(),
        password: this.addressForm.password().value()
      }).subscribe({
        next: (response) => {
          if (response.isValid) {
            this.storage.setAuth(
              this.addressForm.email().value(),
              this.addressForm.password().value());

            this.router.navigateByUrl('');
          } else {
            alert(response.errorMessage);
          }
        },
        error: (error) => {
          alert('Error verifying credentials: ' + error.message);
        }
      });
    }
  }
}
