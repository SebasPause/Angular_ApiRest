import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-loggued',
  templateUrl: './menu-loggued.component.html',
  styleUrls: ['./menu-loggued.component.css']
})
export class MenuLogguedComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit() {
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/inicio']);
  }

}
