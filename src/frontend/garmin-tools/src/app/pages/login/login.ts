import { Component, inject } from '@angular/core';

import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { GarminAuthStorage } from '../../services/local-storage/garmin-auth-storage';

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
    ReactiveFormsModule
  ]
})
export class Login {
  private fb = inject(FormBuilder);
  private storage = inject(GarminAuthStorage);

  addressForm = this.fb.group({
    email: [null, Validators.required],
    password: [null, Validators.required],
  });

  onSubmit(): void {
    if (!this.addressForm.invalid) {
          alert('form invalid!');
      return;
    }

    alert('Thanks!');
    this.storage.setAuth(
      this.addressForm.controls.email.value!,
      this.addressForm.controls.password.value!);
  }
}
