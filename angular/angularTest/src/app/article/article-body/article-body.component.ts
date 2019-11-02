import { Component, OnInit, Input} from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { Article } from '../../article.models';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-article-body',
  templateUrl: './article-body.component.html',
  styleUrls: ['./article-body.component.scss']
})
export class ArticleBodyComponent implements OnInit {
  @Input() article: Article;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private sanitizer: DomSanitizer) {
  }

  ngOnInit() {
  }
}
