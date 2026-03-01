import { Component, OnInit } from '@angular/core';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatDialogRef, MatDialogActions, MatDialogContent, MatDialogTitle, MatDialogClose } from "@angular/material/dialog";
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-remove-all-courses-dialog',
  imports: [MatDialogActions, MatDialogContent,     MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatButtonModule,
  MatIconModule],
  templateUrl: './remove-all-courses-dialog.html',
  styleUrl: './remove-all-courses-dialog.css',
})
export class RemoveAllCoursesDialog {
   constructor(private dialogRef: MatDialogRef<RemoveAllCoursesDialog>) {}



    removeAll() {
        this.dialogRef.close({removeAll: true});
    }

    close() {
        this.dialogRef.close();
    }

}
