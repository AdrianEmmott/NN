import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ImageUploadService {

  constructor(private httpClient: HttpClient) { }

  setImageMainArticle(file: File): Observable<any> {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    const formData: FormData = new FormData();
    formData.append('fileKey', file, file.name);

    return this.httpClient.post('https://localhost:8080/api/file-manager/upload/image'
      , formData
      , { headers: myHeaders });
  }
}
