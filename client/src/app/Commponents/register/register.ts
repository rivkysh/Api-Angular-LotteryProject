import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../Services/user-service';
import { Router, RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule,RouterModule,RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
constructor(private router: Router) { }
private userService = inject(UserService);
isRegister:boolean=false;
registerForm:FormGroup=new FormGroup({
  name:new FormControl('',Validators.required),
  username:new FormControl('',Validators.required),
  password:new FormControl('',[Validators.required,Validators.minLength(6)]),
  email:new FormControl('',[Validators.required,Validators.email]),
  phoneNumber:new FormControl(),
});
onSubmit(){
  if(this.registerForm.valid){
    this.userService.register(this.registerForm.value).subscribe({
      next:(response)=>{
        alert("Registration successful!");
        this.registerForm.reset();
       this.router.navigate(['/login']);
      },
      error:(error)=>{
        console.error('Registration error:', error);
        alert("An error occurred during registration. Please try again later.");
      }
    });

}
}
}