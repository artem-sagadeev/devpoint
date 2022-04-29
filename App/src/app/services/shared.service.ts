import { Observable } from "rxjs";
import { Developer } from "../models/developer";
import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class Service {
    readonly ApiUrl = "https://localhost:5001";

    constructor(private http: HttpClient) { }

    getCreators(): Observable<Developer[]> {
        return this.http.get<Developer[]>(this.ApiUrl + "/creators")
    }

    getCreator(creatorId: string): Observable<Developer> {
        return this.http.get<Developer>(this.ApiUrl + "/creators/" + creatorId)
    }
}