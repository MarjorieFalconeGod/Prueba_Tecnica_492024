import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentsDetaiComponent } from './comments-detai.component';

describe('CommentsDetaiComponent', () => {
  let component: CommentsDetaiComponent;
  let fixture: ComponentFixture<CommentsDetaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommentsDetaiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommentsDetaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
