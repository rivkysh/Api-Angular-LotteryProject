import { Component, inject, signal } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ListPrizes } from './Commponents/list-prizes/list-prizes';
import { ReactiveFormsModule } from '@angular/forms';
import { ListDonors } from "./Commponents/list-donors/list-donors";
import { UserService } from '../Services/user-service';
import { CommonModule } from '@angular/common';
import { YourBasket } from "./Commponents/your-basket/your-basket";

@Component({
  selector: 'app-root',
  imports: [ReactiveFormsModule, RouterOutlet, RouterLink, RouterLinkActive, CommonModule, YourBasket],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  public userService = inject(UserService);
  protected readonly title = signal('client');
}
