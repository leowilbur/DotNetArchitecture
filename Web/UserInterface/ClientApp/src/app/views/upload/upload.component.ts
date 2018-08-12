import { Component } from "@angular/core";
import { UploadService } from "../../services/upload.service";

@Component({ selector: "app-upload", templateUrl: "./upload.component.html" })
export class UploadComponent {
    progress: number = 0;

    constructor(private uploadService: UploadService) { }

    upload(files: FileList) {
        this.uploadService.upload(files).subscribe((progress: number) => {
            this.progress = progress;
        });
    }
}
