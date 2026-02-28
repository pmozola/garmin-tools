import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveAllCoursesDialog } from './remove-all-courses-dialog';

describe('RemoveAllCoursesDialog', () => {
  let component: RemoveAllCoursesDialog;
  let fixture: ComponentFixture<RemoveAllCoursesDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoveAllCoursesDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemoveAllCoursesDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
