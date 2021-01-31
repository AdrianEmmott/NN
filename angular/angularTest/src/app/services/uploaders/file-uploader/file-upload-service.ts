import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { AppSettingsService } from '../../app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  controllerName: string;

  constructor(private httpClient: HttpClient
    , private appSettingsService: AppSettingsService) {
      this.controllerName = this.appSettingsService.apiUrl + 'file-manager';
    }

  uploadFile(file: File): Observable<any> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    const formData: FormData = new FormData();
    formData.append('fileKey', file, file.name);

    return this.httpClient.post(this.controllerName + '/upload/file'
      , formData
      , { headers: myHeaders }
      );
  }

  downloadFile(url: string):Observable<any> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/octet-stream');

    return this.httpClient.get(this.controllerName + '/download/file?link=' + url, { responseType: 'blob'});
  }
}
