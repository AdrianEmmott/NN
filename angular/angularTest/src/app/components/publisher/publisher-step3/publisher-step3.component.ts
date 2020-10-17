import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../../../models/article.models';
import { FileUploadService } from '../../../services/uploaders/file-uploader/file-upload-service';

@Component({
  selector: 'app-publisher-step3',
  templateUrl: './publisher-step3.component.html',
  styleUrls: ['./publisher-step3.component.scss']
})
export class PublisherStep3Component implements OnInit {
  @Input() article: Article;

  constructor(private fileUploadService: FileUploadService) { }

  ngOnInit(): void {
    console.log("in there");
    console.log(this.article);
  }

  fileUpload(fileInputEvent: any) {
    var file = fileInputEvent.target.files[0];
    console.log(file);
    
    let upload$ = this.fileUploadService.uploadFile(file);
    
    upload$.subscribe((result: any) => {
      console.log(result);
      console.log(this.article.attachments);
      this.article.attachments.push(result.url);
      console.log(this.article.attachments);      
    });
  }
}
