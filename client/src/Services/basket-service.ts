import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private BaseUrl = "http://localhost:5009/api/Basket";
  
  // ה"פעמון" שלנו - מודיע שמשהו בסל השתנה
  private basketUpdated = new Subject<void>();

  constructor(private http: HttpClient) { }

  // מאפשר לקומפוננטות להירשם לעדכונים
  get basketUpdates$() {
    return this.basketUpdated.asObservable();
  }

  // פונקציה שמפעילה את העדכון
  refreshBasket() {
    this.basketUpdated.next();
  }

  addToBasket(prizeId: number): Observable<any> {
    const token = localStorage.getItem('token'); 
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    
    return this.http.post<any>(`${this.BaseUrl}/AddPrizeToBasket/${prizeId}`, {}, { headers, responseType: 'text' as 'json' })
      .pipe(
        tap(() => this.refreshBasket()) // ברגע שהצליח, נפעיל את העדכון
      );
  }

  getBasket(): Observable<any> {
    const token = localStorage.getItem('token'); 
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    return this.http.get<any>(`${this.BaseUrl}/GetBasketOfUser`, { headers }); 
  }

  removeTicket(prizeId: number): Observable<any> {
    const token = localStorage.getItem('token'); 
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    
    return this.http.delete<any>(`${this.BaseUrl}/DeletePrizeFromBasket/${prizeId}`, { headers, responseType: 'text' as 'json' })
      .pipe(
        tap(() => this.refreshBasket()) // גם במחיקה נפעיל עדכון
      );
  }
  completeOrder(): Observable<any> {
    const token = localStorage.getItem('token'); 
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    return this.http.post<any>(`${this.BaseUrl}/CompleteOrder`, {}, { headers, responseType: 'text' as 'json' })
}
GetParticipantsList(prizeId: number): Observable<any> {
    const token = localStorage.getItem('token'); 
    const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    return this.http.get<any>(`${this.BaseUrl}/GetPurchasesByPrize/${prizeId}`, { headers }); 
  }
}
