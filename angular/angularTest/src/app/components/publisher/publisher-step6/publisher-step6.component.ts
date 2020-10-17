import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../../../models/article.models';


@Component({
  selector: 'app-publisher-step6',
  templateUrl: './publisher-step6.component.html',
  styleUrls: ['./publisher-step6.component.scss']
})
export class PublisherStep6Component implements OnInit {
  @Input() article: Article;
  constructor() { }

  ngOnInit(): void {
  }

}
