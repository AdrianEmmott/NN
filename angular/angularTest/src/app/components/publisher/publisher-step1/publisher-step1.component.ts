import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../../../models/articles/article.models';
import { ImageUploadService } from '../../../services/uploaders/image-uploader/image-upload-service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-publisher-step1',
  templateUrl: './publisher-step1.component.html',
  styleUrls: ['./publisher-step1.component.scss']
})
export class PublisherStep1Component implements OnInit {
  @Input() article: Article;
  @Output() step1Complete = new EventEmitter<boolean>();

  constructor(private imageUploadService: ImageUploadService) {
  }

  ngOnInit() {
  }

  selectImage(fileInputEvent: any) {
    var file = fileInputEvent.target.files[0];

    let upload$ = this.imageUploadService.setImageMainArticle(file);
    upload$.subscribe((result: any) => {
      this.article.headerImage = result.url;
    });
  }

  clearImage() {
    this.article.headerImage = null;
  }
}
