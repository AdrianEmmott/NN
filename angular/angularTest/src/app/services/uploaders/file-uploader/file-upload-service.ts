import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private httpClient: HttpClient) { }

  uploadFile(file: File): Observable<any> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    const formData: FormData = new FormData();
    formData.append('fileKey', file, file.name);

    return this.httpClient.post('https://localhost:8080/api/file-manager/upload/file'
      , formData
      , { headers: myHeaders }
      );
  }

  downloadFile(url: string):Observable<any> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/octet-stream');

    //const formData: FormData = new FormData();
    //formData.append('fileKey', file, file.name);

    return this.httpClient.get('https://localhost:8080/api/file-manager/download/file?link=' + url, { responseType: 'blob'});
  }
}
