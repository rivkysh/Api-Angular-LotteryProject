import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LotteryService {
 private baseUrl = "http://localhost:5009/api/Random";
  constructor(private http: HttpClient) { }
  theRandom(prizeId: number):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/theRandom/${prizeId}`);
  }
  

  
}

