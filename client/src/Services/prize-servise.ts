import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PrizeServise {
  private baseUrl = "http://localhost:5009/api/Prize";
  constructor(private http: HttpClient) { }
  getProducts(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/GetListPrizes`);
  }
  addPrize(prize: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/AddNewPrize`, prize);
  }
  deletePrize(id: number): Observable<any[]> {
    return this.http.delete<any>(`${this.baseUrl}/RemovePrize/${id}`);
  }
  updatePrize(id: number, prize: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/UpdatePrize/${id}`, prize);
  }
  GetDonorDetails(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/GetDonorByPrizeId/${id}`);
  }
  GetPrizeDetails(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/GetPrizeById/${id}`);
  }
  getPrzesByCategory(category: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/GetListPrizesByCategory/${category}`);
  }
}
