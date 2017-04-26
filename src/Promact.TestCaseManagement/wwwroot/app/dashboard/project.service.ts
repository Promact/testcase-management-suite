import { HttpService } from '../core/http.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ProjectService {
    private projectApiUrl = "api/project";

    constructor(private http: HttpService) {
    }

    getProjectList() {
        return this.http.get(this.projectApiUrl);
    }
}