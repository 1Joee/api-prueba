import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { UserFormComponent } from './pages/user-form/user-form.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent, title: 'Login' },
    { path: 'dashboard', component: DashboardComponent, title: 'Dashboard', canActivate: [authGuard] },
    { path: 'users', component: UserListComponent, title: 'Usuarios', canActivate: [authGuard] },
    { path: 'users/new', component: UserFormComponent, title: 'Nuevo usuario', canActivate: [authGuard] },
    { path: '**', redirectTo: '/login' },
];
