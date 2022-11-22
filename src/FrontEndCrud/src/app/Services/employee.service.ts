import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../Interfaces/employee';
import { ResponseAPI } from '../Interfaces/response-api';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {

    private endpoint: string = environment.endpoint;
    private myApiUrl: string = this.endpoint + "api/employee";

    constructor(private http: HttpClient) { }

    getList(): Observable<ResponseAPI> {
        return this.http.get<ResponseAPI>(this.myApiUrl);
    }

    add(request: Employee): Observable<ResponseAPI> {
        return this.http.post<ResponseAPI>(this.myApiUrl, request);
    }

    update(request: Employee): Observable<ResponseAPI> {
        return this.http.put<ResponseAPI>(this.myApiUrl, request);
    }

    delete(id: number): Observable<ResponseAPI> {
        return this.http.delete<ResponseAPI>(`${this.myApiUrl}/${id}`);
    }
}
