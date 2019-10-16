import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePageSidebarLeftComponent } from './message-page-sidebar-left.component';

describe('MessagePageSidebarLeftComponent', () => {
  let component: MessagePageSidebarLeftComponent;
  let fixture: ComponentFixture<MessagePageSidebarLeftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagePageSidebarLeftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagePageSidebarLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
