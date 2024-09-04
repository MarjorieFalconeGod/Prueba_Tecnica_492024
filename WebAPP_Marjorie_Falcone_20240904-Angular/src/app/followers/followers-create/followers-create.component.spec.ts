import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FollowersCreateComponent } from './followers-create.component';

describe('FollowersCreateComponent', () => {
  let component: FollowersCreateComponent;
  let fixture: ComponentFixture<FollowersCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FollowersCreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FollowersCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
