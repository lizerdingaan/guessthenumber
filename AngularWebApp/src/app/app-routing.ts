import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { MenuComponent } from "./components/menu/menu.component";
import { RegisterComponent } from "./components/register/register.component";
import { StartComponent } from "./components/start/start.component";

const APP_ROUTES: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'start', component: StartComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
]

export const routing = RouterModule.forRoot(APP_ROUTES);
