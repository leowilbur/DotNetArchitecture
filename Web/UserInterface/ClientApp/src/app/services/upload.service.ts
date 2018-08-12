import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: "root" })
export class UploadService {
    private service = "Upload";

    constructor(private readonly http: HttpClient) { }

    upload(files: FileList): Observable<number> {
        if (files.length === 0) {
            return of(0);
        }

        const formData = new FormData();

        for (const file of files as any) {
            formData.append(file.name, file);
        }

        const request = new HttpRequest("POST", this.service, formData, { reportProgress: true, });

        return new Observable((result) => {
            this.http.request(request).subscribe((event) => {
                if (event.type === HttpEventType.UploadProgress) {
                    const progress = Math.round(100 * event.loaded / event.total);

                    if (progress < 100) {
                        result.next(progress);
                        return;
                    }
                }

                if (event.type === HttpEventType.Response) {
                    result.next(100);
                    return;
                }
            });
        });
    }
}
