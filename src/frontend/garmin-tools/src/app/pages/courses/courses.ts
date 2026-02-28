import { Component, inject } from '@angular/core';
import { GarminCoursesApi } from '../../services/api/courses/garmin-courses-api';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-courses',
  imports: [AsyncPipe],
  templateUrl: './courses.html',
  styleUrl: './courses.css',
})
export class Courses {
  private coursesApi = inject(GarminCoursesApi);

  courses$ = this.coursesApi.getAll();
}
