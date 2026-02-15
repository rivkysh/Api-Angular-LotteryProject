import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DonorService {
  private BaseUrl = "http://localhost:5009/api/Doner";
   constructor(private http: HttpClient) { }
    getDonors():Observable<any[]> {
     return this.http.get<any[]>(`${this.BaseUrl}/GetListDoners`);
    }
    deleteDonor(id: number): Observable<any> {
      return this.http.delete<any>(`${this.BaseUrl}/RemoveDonor/${id}`);
    }
    editDonor(id: number, donorData: any): Observable<any> {
      return this.http.put<any>(`${this.BaseUrl}/UpdateDonor/${id}`, donorData);
    }
    addDonor(donorData: any): Observable<any> {
      return this.http.post<any>(`${this.BaseUrl}/AddNewDonor`, donorData);
    }
    getPrizesByDonor(donorId: number): Observable<any[]> {
      return this.http.get<any[]>(`${this.BaseUrl}/GetPrizesByDonor/${donorId}`);
    }
    sortByName(name:string): Observable<any[]> {
      return this.http.get<any[]>(`${this.BaseUrl}/GetDonorByName/${name}`);
    }
    sortByEmail(email:string): Observable<any[]> {
      return this.http.get<any[]>(`${this.BaseUrl}/GetDonorByEmail/${email}`);
    }
    sortByPrize(prize:string): Observable<any[]> {
      return this.http.get<any[]>(`${this.BaseUrl}/GetDonorByPrize/${prize}`);
    }
}
