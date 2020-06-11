import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ArticlePublisherService } from 'src/app/services/article.publisher.service';
import { ArticleService } from 'src/app/services/article.service';
import { Article } from '../../../models/article.models';
import SimpleFileUpload from '@samhammer/ckeditor5-simple-image-upload-plugin';

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
    const myPlugin = new SimpleFileUpload();
    const config = {
      extraPlugins: [myPlugin]
    };
    this.Editor.extraPlugins = config;
    // this.Editor.plugins.get( FileRepository ).createUploadAdapter = loader => new Adapter( loader );
    // console.log(ClassicEditor.builtinPlugins.map( plugin => plugin.pluginName ));
  }
}
