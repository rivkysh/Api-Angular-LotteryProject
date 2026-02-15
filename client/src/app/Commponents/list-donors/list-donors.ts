import { Component, inject } from '@angular/core';
import { DonorService } from '../../../Services/donor-service';
import { EditDonor } from "../edit-donor/edit-donor";
import { AddNewDonor } from "../add-new-donor/add-new-donor";
import { GetPrizesByDonor } from "../get-prizes-by-donor/get-prizes-by-donor";
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../Services/user-service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-list-donors',
  imports: [EditDonor, AddNewDonor, GetPrizesByDonor,FormsModule],
  templateUrl: './list-donors.html',
  styleUrl: './list-donors.scss',
})
export class ListDonors {
private donorService = inject(DonorService);
allDonors:any[]=[];
thisDonor:any=null;
thisId:number=0;
openEdit:boolean=false;
OpenInsert:boolean=false;
openPrizes:boolean=false;
thisName:string="";
searchTerm:string="";
private userService = inject(UserService);
public location = inject(Location);
token: string | null = localStorage.getItem('token');
ngOnInit() {
  if(this.userService.isUser()){
    alert("אין לך הרשאות מתאימות להיכנס לעמוד זה.");
   this.location.back();
  }
  this.donorService.getDonors().subscribe(data => {
    this.allDonors = data;
    console.log(this.allDonors);
  });
}
deleteDonor(id: number) {
  const isConfirmed = confirm('האם אתה בטוח שברצונך למחוק את התורם הזה לצמיתות?');
  if (isConfirmed) {
    this.donorService.deleteDonor(id).subscribe(() => {
    this.allDonors = this.allDonors.filter(donor => donor.id !== id);
    alert("התורם נמחק בהצלחה");
  }, (error) => {
    console.error('שגיאה במחיקת התורם:', error);
    alert("אירעה שגיאה בעת מחיקת התורם. אנא נסה שוב מאוחר יותר.");
  });
  
    }
}
editDonor(id: number,donor:any) {
  this.openEdit = true;
  this.thisDonor=donor;
  this.thisId = id;
}
onCloseDialog() {
  this.openEdit = false;
  this.thisDonor = null;
  this.thisId = 0;
  this.reloadDonors();
}
reloadDonors() {
  this.donorService.getDonors().subscribe(data => {
    this.allDonors = data;
    console.log(this.allDonors);
  });
}
openAddNewDonor(){
  this.OpenInsert=true;
}
onCloseInsert(){
  this.OpenInsert=false;
  this.reloadDonors();
}
ShowPrizes(donorId: number,donorName:string){
this.thisName=donorName; 
this.openPrizes=true
this.thisId=donorId;
}
onClosePrizes(){
  this.openPrizes=false;
  this.thisId=0;  
}
sortByName(){
  this.donorService.sortByName(this.searchTerm).subscribe(data => {
    this.allDonors = data;
    console.log(this.allDonors);
  });
}
sortByEmail(){
  this.donorService.sortByEmail(this.searchTerm).subscribe(data => {
    this.allDonors = data;
    console.log(this.allDonors);
  });
}
sortByPrize(){
  this.donorService.sortByPrize(this.searchTerm).subscribe(data => {
    this.allDonors = data;
    console.log(this.allDonors);
  });
}
getAll(){
  this.reloadDonors();
}
}
