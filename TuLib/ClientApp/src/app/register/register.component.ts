import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public service: UserService,private router:Router) { }

  ngOnInit() {
    this.service.formModel.reset();
    if (localStorage.getItem('token') != null) {
      this.router.navigate(['/libros']);
    }
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          alert("Registro completado con exito");
        } else {
          var isDuplicate = false;
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateEmail':
                isDuplicate = true;
                break;              
              case 'DuplicateUserName':
                //El usuario no esta disponible
                isDuplicate = true;
                break;
              default:
                //Registro fallido
                alert("Registro fallido,vuelva a intentarlo");
                break;
            }
          });
          if (isDuplicate)
            alert("Usuario duplicado, vuelva a intentarlo");

        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
