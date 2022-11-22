import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseAPI } from '../Interfaces/response-api';

@Injectable({
    providedIn: 'root'
})
export class DepartmentService {

    private endpoint: string = environment.endpoint;
    private myApiUrl: string = this.endpoint + "api/department";

    constructor(private http: HttpClient) { }

    getList(): Observable<ResponseAPI> {
        return this.http.get<ResponseAPI>(this.myApiUrl);
    }
}
