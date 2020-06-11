import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleMetadataComponent } from './article-metadata.component';

describe('ArticleMetadataComponent', () => {
  let component: ArticleMetadataComponent;
  let fixture: ComponentFixture<ArticleMetadataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticleMetadataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleMetadataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
