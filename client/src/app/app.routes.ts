import { Routes } from '@angular/router';
import { ListPrizes } from './Commponents/list-prizes/list-prizes';
import { ListDonors } from './Commponents/list-donors/list-donors';
import { Register } from './Commponents/register/register';
import { Login } from './Commponents/login/login';
import { AllPrizes } from './Commponents/all-prizes/all-prizes';
import { PrizeDedailes } from './Commponents/prize-dedailes/prize-dedailes';
import { YourBasket } from './Commponents/your-basket/your-basket';
import { HomePage } from './Commponents/home-page/home-page';

export const routes: Routes =
    [{ path: 'prizes', component: ListPrizes },
     {path: 'homePage', component: HomePage },
    { path: 'donors', component: ListDonors },
    { path: '', redirectTo: '/prizesHome', pathMatch: 'full' },
    { path: 'register', component: Register },
    { path: 'login', component: Login },
    { path: 'prizesHome', component: AllPrizes },
    { path: 'gift-details/:id', component: PrizeDedailes },
    { path: 'yourBasket', component: YourBasket }
    
    ];

