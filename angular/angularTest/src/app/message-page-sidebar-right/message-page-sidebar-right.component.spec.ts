import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePageSidebarRightComponent } from './message-page-sidebar-right.component';

describe('MessagePageSidebarRightComponent', () => {
  let component: MessagePageSidebarRightComponent;
  let fixture: ComponentFixture<MessagePageSidebarRightComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagePageSidebarRightComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagePageSidebarRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
