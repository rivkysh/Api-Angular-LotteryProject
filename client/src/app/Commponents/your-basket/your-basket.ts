import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { BasketService } from '../../../Services/basket-service';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-your-basket',
  imports: [CommonModule, RouterLink],
  templateUrl: './your-basket.html',
  styleUrl: './your-basket.scss',
})
export class YourBasket {
public BasketService = inject(BasketService)
basketData:any;
ngOnInit(){
    this.loadBasket();

    this.BasketService.basketUpdates$.subscribe(() => {
      this.loadBasket();
    });
  }
groupedTickets: any[] = [];
loadBasket() {
  this.BasketService.getBasket().subscribe(data => {
    this.basketData = data;
    this.groupTickets(); // קריאה לפונקציית הקיבוץ
  });
}

groupTickets() {
  const groups = new Map();

  this.basketData.yourTickets.forEach((ticket: any) => {
    const id = ticket.prize.id;
    if (groups.has(id)) {
      groups.get(id).quantity += 1; // כאן נוצרת הכמות
    } else {
      groups.set(id, { ...ticket, quantity: 1 }); // כאן היא מתחילה ב-1
    }
  });

  this.groupedTickets = Array.from(groups.values());
}
removeTicket(prizeId: number) {
  const isConfirmed = confirm('האם אתה בטוח שברצונך למחוק את הפרס הזה לצמיתות?');
    if (isConfirmed) {
  this.BasketService.removeTicket(prizeId).subscribe({
    next: (res) => {
      console.log('Ticket removed successfully:', res);
    }
  ,    error: (err) => {
      console.error('Error removing ticket:', err);
    }
  }); 
}
}
completOrder(){
  const isConfirmed = confirm('האם אתה בטוח שברצונך להשלים את ההזמנה? פעולה זו לא ניתנת לביטול.');
    if (isConfirmed) {
  this.BasketService.completeOrder().subscribe({
    
    next: (res) => {
      alert('ההזמנה הושלמה בהצלחה!');
      this.loadBasket(); // רענון הסל לאחר השלמת ההזמנה
    },
    error: (err) => {
      console.error('Error completing order:', err);
      alert('אירעה שגיאה בהשלמת ההזמנה. אנא נסה שוב.');
    }
  });
}
}
totalCount(): number {
  let total=0;
  this.groupedTickets.forEach(ticket=>{
    total+=ticket.prize.price*ticket.quantity;
  })
  return total;
}
}