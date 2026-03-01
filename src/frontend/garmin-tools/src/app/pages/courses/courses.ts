import { Component, inject, OnInit } from '@angular/core';
import { GarminCoursesApi, GetAllCoursesQueryResponse } from '../../services/api/courses/garmin-courses-api';

import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SelectionModel } from '@angular/cdk/collections';
import { CoursesDataSource } from './courses.datasource';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { RemoveAllCoursesDialog } from './remove-all-courses-dialog/remove-all-courses-dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from "@angular/material/icon";
import { DatePipe, DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-courses',
  imports: [MatTableModule, MatCheckboxModule, MatButtonModule, MatIconModule, DecimalPipe, DatePipe],
  templateUrl: './courses.html',
  styleUrl: './courses.css',
})
export class Courses implements OnInit {

  api = inject(GarminCoursesApi);
  dialog = inject(MatDialog);
  dataSource = new CoursesDataSource(this.api);
  displayedColumns: string[] = ['select', 'id', 'name', 'createdAt', 'distanceInMeters', 'elevationGainInMeters', 'goToWebsite'];

  selection = new SelectionModel<GetAllCoursesQueryResponse>(true, []);

  ngOnInit(): void {
    this.dataSource.loadCourses();
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.currentData.length;
    return numSelected === numRows;
  }

  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.currentData);
  }

  checkboxLabel(row?: GetAllCoursesQueryResponse): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id}`;
  }

  deleteRows() {
    // If all rows are selected, show confirmation dialog before deleting
    if (this.isAllSelected()) {
      this.openDialog().afterClosed().subscribe(result => {
        if (result && result.removeAll) {
          console.log('User confirmed to delete all courses');
          //this.removeSelectedCourses();
          this.dialog.closeAll();
        } else {
          this.dialog.closeAll();
        }
      });
    } else {
      this.removeSelectedCourses();
    }

  }

  removeSelectedCourses() {
    this.api.Remove(this.selection.selected.map(row => row.id)).subscribe(() => {
      this.selection.clear();
      console.log('Deleted courses with ids: ' + this.selection.selected.map(row => row.id).join(', '));
      this.dataSource.loadCourses();
    });
  }

  openDialog(): MatDialogRef<RemoveAllCoursesDialog, any> {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(RemoveAllCoursesDialog, dialogConfig);

    return dialogRef;
  }
}
