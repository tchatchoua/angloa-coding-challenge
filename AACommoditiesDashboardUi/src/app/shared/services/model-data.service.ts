import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TradeModel } from "src/app/models";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})
export class ModelDataService {
    
    private _baseUrl  = environment.commoditiesApi;

    constructor(private http: HttpClient) {}

    public getAll():Observable<TradeModel[]> {
       return this.http.get<TradeModel[]>(`${this._baseUrl}/models`)
       .pipe(
        catchError(err=> {
            console.error(err);
            return of([])
        })
       );
    }
}