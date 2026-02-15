import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../Services/user-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  private userService = inject(UserService);
  constructor(private router: Router) { }

loginForm:FormGroup=new FormGroup({
  username:new FormControl('',Validators.required),
  password:new FormControl('',Validators.required),
}
);
onSubmit(){
  if(this.loginForm.valid){
    this.userService.login(this.loginForm.value).subscribe({
      next:(response)=>{
        alert("Login successful!");
        this.loginForm.reset();
        localStorage.setItem('token', response.token);
        localStorage.setItem('username', this.loginForm.value.username);
        localStorage.setItem('role', response.role);
        if(response.role==='Admin'){
         this.router.navigate(['/donors']);
        }else{
         this.router.navigate(['/prizesHome']);
        }
      },
      error:(error)=>{
        console.error('Login error:', error);
        alert("An error occurred during login. Please try again later.");
      }
  });
}
}
pathToResister(){
  this.router.navigate(['/register']);
}
}