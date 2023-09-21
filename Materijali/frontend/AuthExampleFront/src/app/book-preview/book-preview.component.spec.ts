import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookPreviewComponent } from './book-preview.component';

describe('BookPreviewComponent', () => {
  let component: BookPreviewComponent;
  let fixture: ComponentFixture<BookPreviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookPreviewComponent]
    });
    fixture = TestBed.createComponent(BookPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
