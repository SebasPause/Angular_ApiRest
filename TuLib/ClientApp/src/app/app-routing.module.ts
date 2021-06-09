import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { LibrosComponent } from './libros/libros.component';
import { ValoracionesComponent } from './valoraciones/valoraciones.component';
import { AuthGuard } from './auth/auth.guard';
import { ContenidoComponent } from './libros/contenido/contenido.component';

const routes: Routes = [
  { path: 'inicio', component: HomeComponent },
  { path: 'signIn', component: LoginComponent },
  { path: 'signUp', component: RegisterComponent },
  { path: 'libros', component: LibrosComponent, canActivate: [AuthGuard] },
  { path: 'valoraciones', component: ValoracionesComponent, canActivate: [AuthGuard] },
  { path: 'contenido', component: ContenidoComponent},

  { path: '', redirectTo: '/inicio', pathMatch: 'full' },
];


@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
