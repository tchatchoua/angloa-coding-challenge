import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of} from 'rxjs';
import { catchError} from 'rxjs/operators';
import { Commodity } from "src/app/models";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})
export class CommodityDataService {

    private _baseUrl  = environment.commoditiesApi;

    constructor(private http: HttpClient) {}
    
    public getByModelId(modelid:number):Observable<Commodity[]> {
        return this.http.get<Commodity[]>(`${this._baseUrl}/commodities/${modelid}`)
        .pipe(
            catchError(err=> {
                console.error(err);
                return of([])
            })
        );
    }
}