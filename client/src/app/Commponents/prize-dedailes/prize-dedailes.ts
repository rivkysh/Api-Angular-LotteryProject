import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrizeServise } from '../../../Services/prize-servise';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { BasketService } from '../../../Services/basket-service';

@Component({
  selector: 'app-prize-dedailes',
  imports: [CommonModule],
  templateUrl: './prize-dedailes.html',
  styleUrl: './prize-dedailes.scss',
})
export class PrizeDedailes {
gift: any;
public BasketService = inject(BasketService);
  constructor(
    private route: ActivatedRoute,
  ) {}
private giftService=inject(PrizeServise);
  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    
    this.giftService.GetPrizeDetails(id).subscribe(data => {
      this.gift = data;
    });
  }
  backToPrizes() {
    window.history.back();
  }
  addToBasket(id: number) {
    // הגדרת העיצוב של ה-Toast
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
  
    // שליחת הבקשה לשרת
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
  }
}
