import { RouterModule, Routes } from "@angular/router";
import { HistoryComponent } from "./components/history/history.component";
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
  { path: 'menu/:username', component: MenuComponent },
  { path: 'history/:username', component: HistoryComponent },
  { path: 'start/:username', component: StartComponent },
  { path: 'history', component: HistoryComponent },
  { path: 'exit', component: HomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'backtomenu', component: MenuComponent }
]

export const routing = RouterModule.forRoot(APP_ROUTES);
