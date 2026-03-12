import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-change-device',
  imports: [MatIconModule],
  templateUrl: './change-device.html',
  styleUrl: './change-device.css',
})
export class ChangeDevice {
  fileName = '';
  constructor(private readonly http: HttpClient) { }

  onFileSelected(event: any) {

    const file: File = event.target.files[0];
    console.log(file);
    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("File", file);
      formData.append("UseDefaultDevice", "true");

      this.http
        .post('FitFile/change', formData, { responseType: 'blob' })
        .subscribe((blob: Blob) => {
          // create a temporary link and click it
          const url = window.URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          // you can use fileName or whatever name you want
          a.download = 'export.fit';
          a.click();
          window.URL.revokeObjectURL(url);
        },
          err => {
            console.error('download failed', err);
          });
    }
  }
}
