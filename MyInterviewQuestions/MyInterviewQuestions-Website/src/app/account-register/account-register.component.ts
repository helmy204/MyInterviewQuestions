import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { User } from '../User';

@Component({
  selector: 'app-account-register',
  templateUrl: './account-register.component.html',
  styleUrls: ['./account-register.component.css']
})
export class AccountRegisterComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }

  register(userName: string,password:string,confirmPassword:string): void {

    //console.log(userName);

    userName= userName.trim(); password= password.trim(); confirmPassword= confirmPassword.trim();
    if(!userName||!password ||!confirmPassword) {return;}
    
    this.accountService.register({userName,password,confirmPassword} as User).subscribe();
      
  }

}
