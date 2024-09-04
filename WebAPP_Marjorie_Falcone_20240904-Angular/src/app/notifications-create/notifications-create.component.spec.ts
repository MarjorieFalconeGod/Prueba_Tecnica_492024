import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationsCreateComponent } from './notifications-create.component';

describe('NotificationsCreateComponent', () => {
  let component: NotificationsCreateComponent;
  let fixture: ComponentFixture<NotificationsCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotificationsCreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationsCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
