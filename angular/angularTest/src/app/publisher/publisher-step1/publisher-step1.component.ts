import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../../article.models';

@Component({
  selector: 'app-publisher-step1',
  templateUrl: './publisher-step1.component.html',
  styleUrls: ['./publisher-step1.component.scss']
})
export class PublisherStep1Component implements OnInit {
  @Input() article: Article;
  @Output() step1Complete = new EventEmitter<boolean>();

  constructor() {
  }

  ngOnInit() {
  }
}
