import { Component, inject } from '@angular/core';
import { PrizeServise } from '../../../Services/prize-servise';
import { AddNewPrize } from '../add-new-prize/add-new-prize';
import { UpdatePrize } from "../update-prize/update-prize";
import { DonorDetails } from "../donor-details/donor-details";
import { BasketService } from '../../../Services/basket-service';
import { GetPurchases } from "../get-purchases/get-purchases";
import { LotteryService } from '../../../Services/lottery-service';

@Component({
  selector: 'app-list-prizes',
  imports: [AddNewPrize, UpdatePrize, DonorDetails, GetPurchases],
  templateUrl: './list-prizes.html',
  styleUrl: './list-prizes.scss',
})
export class ListPrizes {
  public PrizeService = inject(PrizeServise)
  public BasketService = inject(BasketService)
  public lotteryService = inject(LotteryService)
  allprizes: any[] = []
  degel: boolean = false;
  openUpdateDialog: boolean = false;
  thisPrize: any = null;
  id: number = 0;
  theDonerDetails: any = null;
  openDonerDetails: boolean = false;
  openUsers: boolean = false;
  usersList: any[] = [];
  ngOnInit() {
    this.PrizeService.getProducts().subscribe(data => {
      this.allprizes = data;
      console.log(this.allprizes);
    });
  }
  addNewPrize() {
    this.degel = true;
  }
  loadPrizes() {
    this.PrizeService.getProducts().subscribe(data => {
      this.allprizes = data;
    });
  }

  onCloseDialog() {
    this.degel = false;
    this.openUpdateDialog = false;
    this.loadPrizes();
  }
  onCloseDialogDonerDetails() {
    this.openDonerDetails = false;
    this.theDonerDetails = null;
  }
  onCloseDialogUsers() {
    this.openUsers = false;
    this.usersList = [];
  }
  deletePrize(id: number) {
    const isConfirmed = confirm('האם אתה בטוח שברצונך למחוק את הפרס הזה לצמיתות?');
    if (isConfirmed) {
      this.PrizeService.deletePrize(id).subscribe(() => {
        this.allprizes = this.allprizes.filter(gift => gift.id !== id);
        alert("הפרס נמחק בהצלחה");
      }, (error) => {
        console.error('שגיאה במחיקת הפרס:', error);
        alert("אירעה שגיאה בעת מחיקת הפרס. אנא נסה שוב מאוחר יותר.");
      });
    }
  }
  updatePrize(id: number, prize: any) {
    this.id = id;
    this.openUpdateDialog = true
    this.thisPrize = prize;
  }
  GetDonorDetails(id: number) {
    this.PrizeService.GetDonorDetails(id).subscribe({
      next: (data) => {
        this.theDonerDetails = data;
        console.log('נתוני התורם שהתקבלו:', this.theDonerDetails);
        this.openDonerDetails = true;
      },
      error: (err) => {
        console.error('שגיאה במשיכת פרטי תורם:', err);
      }
    });
  }
  GetParticipantsList(id: number) {
    this.BasketService.GetParticipantsList(id).subscribe({
      next: (data: any[]) => {
        this.usersList = data.reduce((acc: any[], current: any) => {
          const existingUser = acc.find(item => item.user.id === current.user.id);
          if (existingUser) {
            existingUser.ticketsAmaunt += current.ticketsAmaunt;
          } else {
            acc.push({ ...current });
          }
          return acc;
        }, []);

        console.log('נתוני המשתתפים ללא כפילויות:', this.usersList);
        this.openUsers = true;
      },
      error: (err) => {
        console.error('שגיאה במשיכת רשימת המשתתפים:', err);
      }
    });
  }
  runDraw(prizeId: number) {
    this.lotteryService.theRandom(prizeId).subscribe({
      next: (data) => {
        if(!data){
          alert("אין משתתפים בהגרלה זו, לא ניתן לבצע הגרלה.");
          return;
        }
        alert(`המנצח הוא: ${data.thewinner.name})!`);
        this.loadPrizes(); 
      },
      error: (err) => {
        console.error('שגיאה בהרצת ההגרלה:', err);
        alert("אירעה שגיאה בעת הרצת ההגרלה. אנא נסה שוב מאוחר יותר.");
      }
    });
  }
}