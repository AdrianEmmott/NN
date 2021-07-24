import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { Article } from '../../../models/article.models';
import { FileUploadService } from '../../../services/uploaders/file-uploader/file-upload-service';

@Component({
  selector: 'app-article-attachments',
  templateUrl: './article-attachments.component.html',
  styleUrls: ['./article-attachments.component.scss']
})
export class ArticleAttachmentsComponent implements OnInit {
  @Input() article: Article;

  constructor(private fileUploadService: FileUploadService) { }

  ngOnInit(): void {
  }

  downloadFile(link: string) {
    let filename = link.substring(link.lastIndexOf('/')+1);

    let download$ = this.fileUploadService.downloadFile(link);

    download$.subscribe((result: any) => {
      var file = new File([result], filename, { type: "text/json;charset=utf-8" });

      let downloadLink = document.createElement('a');
      downloadLink.href = window.URL.createObjectURL(file);
      downloadLink.setAttribute('download', filename);
    
      document.body.appendChild(downloadLink);
      downloadLink.click();
    });
  }
}
