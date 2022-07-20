import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Trade } from "src/app/models";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})
export class TradeDataService {
    
    private _baseUrl  = environment.commoditiesApi;

    constructor(private http: HttpClient) {}

    public getByCommodityId(commodityId:number):Observable<Trade[]> {
       return this.http.get<Trade[]>(`${this._baseUrl}/trades/${commodityId}`)
       .pipe(
        catchError(err=> {
            console.error(err);
            return of([])
        })
       );
    }
}