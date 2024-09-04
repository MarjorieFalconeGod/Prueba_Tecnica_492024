import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationsEditComponent } from './notifications-edit.component';

describe('NotificationsEditComponent', () => {
  let component: NotificationsEditComponent;
  let fixture: ComponentFixture<NotificationsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotificationsEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
