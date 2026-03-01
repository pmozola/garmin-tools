import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { GarminCoursesApi, GetAllCoursesQueryResponse } from "../../services/api/courses/garmin-courses-api";
import { BehaviorSubject, catchError, finalize, Observable, of, tap } from "rxjs";

export class CoursesDataSource implements DataSource<GetAllCoursesQueryResponse> {

    private courseSubject = new BehaviorSubject<GetAllCoursesQueryResponse[]>([]);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public loading$ = this.loadingSubject.asObservable();
    public currentData: GetAllCoursesQueryResponse[] = [];

    constructor(private api: GarminCoursesApi) { }

    connect(collectionViewer: CollectionViewer): Observable<GetAllCoursesQueryResponse[]> {
        return this.courseSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.courseSubject.complete();
        this.loadingSubject.complete();
    }

    loadCourses() {

        this.loadingSubject.next(true);

        this.api.getAll().pipe(
            tap(courses => this.currentData = courses),
            catchError(() => of([])),
            finalize(() => this.loadingSubject.next(false))
        )
            .subscribe(courses => this.courseSubject.next(courses));
    }
}