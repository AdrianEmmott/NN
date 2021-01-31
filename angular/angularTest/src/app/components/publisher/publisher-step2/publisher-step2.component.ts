import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ArticlePublisherService } from 'src/app/services/article.publisher.service';
import { ArticleService } from 'src/app/services/article.service';
import { Article } from '../../../models/article.models';

import * as CEditor from 'src/assets/my-ckeditor-build/ckeditor.js';



@Component({
  selector: 'app-publisher-step2',
  templateUrl: './publisher-step2.component.html',
  styleUrls: ['./publisher-step2.component.scss']
})
export class PublisherStep2Component implements OnInit {
  constructor(private articleService: ArticleService,
    private articlePublisherService: ArticlePublisherService,
    ) {
    }


  ngOnInit() {
  }


  @Input() article: Article;

  public Editor = CEditor;

  public editorConfig = {
    simpleUpload: {
      uploadUrl: 'https://localhost:8090/api/file-manager/upload/image',
      withCredentials: false,
       headers: {
         //'X-CSRF-TOKEN': 'CSFR-Token',
         //    Authorization: 'Bearer <JSON Web Token>',
       }
    },
    toolbar: {
      items: [
        'heading', '|',
        'bold',
        'italic',
        'underline',
        'link',
        'bulletedList',
        'numberedList',
        '|',
        'indent',
        'outdent',
        '|',
        'imageUpload',
        'blockQuote',
        'mediaEmbed',
        'insertTable',
        'undo',
        'redo',
      ]
    },
    image: {
      toolbar: [
        'imageStyle:full',
        'imageStyle:side',
        '|',
        'imageTextAlternative'
      ]
    },
    table: {
      contentToolbar: [
        'tableColumn',
        'tableRow',
        'mergeTableCells'
      ]
    },
    // This value must be kept in sync with the language defined in webpack.config.js.
    language: 'en'
  };
}
