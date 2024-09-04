import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowersEditComponent } from './followers-edit.component';

describe('FollowersEditComponent', () => {
  let component: FollowersEditComponent;
  let fixture: ComponentFixture<FollowersEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FollowersEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FollowersEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
