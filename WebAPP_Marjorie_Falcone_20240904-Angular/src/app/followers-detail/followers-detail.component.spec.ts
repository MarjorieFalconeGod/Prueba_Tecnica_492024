import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowersDetailComponent } from './followers-detail.component';

describe('FollowersDetailComponent', () => {
  let component: FollowersDetailComponent;
  let fixture: ComponentFixture<FollowersDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FollowersDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FollowersDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
