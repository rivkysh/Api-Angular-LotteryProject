import { Component, inject } from '@angular/core';
import { PrizeServise } from '../../../Services/prize-servise';
import { RouterLink } from "@angular/router";
import { BasketService } from '../../../Services/basket-service';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs';

@Component({
  selector: 'app-all-prizes',
  imports: [RouterLink,CommonModule],
  templateUrl: './all-prizes.html',
  styleUrl: './all-prizes.scss',
})
export class AllPrizes {
public PrizeService = inject(PrizeServise)
public BasketService = inject(BasketService)
allprizes:any[]=[]
quantity:number=0;
ngOnInit(){
this.PrizeService.getProducts().subscribe(data => {
      this.allprizes = data;
      console.log(this.allprizes);
});
}
addQuantity(gift:any){
  gift.quantity+=1
}
lessQuantity(gift:any){
  if(gift.quantity>1)
  gift.quantity-=1
}
addToBasket(id: number,quantity:number) {
 let token=localStorage.getItem('token');
 if(!token){
  Swal.fire({
    icon: 'warning',
    title: 'עליך להתחבר כדי להוסיף פרס לסל',
    confirmButtonText: 'אישור',
    background: '#1a1a1a', 
    color: '#fcf6ba',     
  });
  return;
 }
  const Toast = Swal.mixin({
    toast: true,
    position: 'center', // יופיע בצד ימין למעלה
    showConfirmButton: false,
    timer: 3000, // ייעלם אחרי 3 שניות
    timerProgressBar: true,
    background: '#1a1a1a', // רקע כהה
    color: '#fcf6ba',      // טקסט זהב
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer)
      toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
  });
  while(quantity>0){
 this. BasketService.addToBasket(id).subscribe({
    next: (res) => {
      Toast.fire({
        icon: 'success',
        iconColor: '#bf953f', // אייקון בצבע זהב
        title: 'המתנה נוספה לסל בהצלחה!'
      });
    },
    error: (err) => {
      Toast.fire({
        icon: 'error',
        title: 'אופס... משהו השתבש'
      });
    }
  });
quantity--;
  }
}
getByCategory(categoryName: string) {
  if (categoryName === 'all' ) {
    this.PrizeService.getProducts().subscribe((res: any) => {
      this.allprizes = res.value ? res.value : res;
    });
  } else {
    this.PrizeService.getPrzesByCategory(categoryName).subscribe((res: any) => {
      if (res && res.value) {
        this.allprizes = res.value; 
      } else {
        this.allprizes = Array.isArray(res) ? res : (res ? [res] : []);
      }
    });
  }
}
filteredPrizes: any[] = [];
filterByPrice(maxPrice: number) {
  this.filteredPrizes = [];
  this.allprizes.forEach(element => {
    if (element.price <= maxPrice) {
      this.filteredPrizes.push(element);
    }
  });
  this.allprizes = this.filteredPrizes;
}
}