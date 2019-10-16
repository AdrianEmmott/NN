import { Component, OnInit, Input , Output, EventEmitter } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ArticlePublisherService } from 'src/app/article.publisher.service';
import { ArticleService } from 'src/app/article.service';
import { Article } from '../../article.models';

@Component({
  selector: 'app-publisher-step2',
  templateUrl: './publisher-step2.component.html',
  styleUrls: ['./publisher-step2.component.scss']
})
export class PublisherStep2Component implements OnInit {
  @Input() article: Article;
  public Editor = ClassicEditor;

  constructor(private articleService: ArticleService,
              private articlePublisherService: ArticlePublisherService) { }

  ngOnInit() {
  }
}
