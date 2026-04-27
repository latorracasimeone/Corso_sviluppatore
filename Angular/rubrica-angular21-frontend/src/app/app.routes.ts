import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { guestGuard } from './core/guards/guest.guard';
import { roleGuard } from './core/guards/role.guard';
//con load component carica le pagine in lazy loading (?)
export const routes: Routes = [
    (
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard'
    ),
    (
        path: 'login',
        canActivate: [guestGuard],
        loadComponent: () => import('./pages/login/login.page').then((m) => m.LoginPage)
    ),
    (
        path: 'register',
        canActivate: [guestGuard],
        loadComponent: () => import('./pages/register/register.page').then((m) => m.RegisterPage)
    ),
    (
        path: 'dashboard',
        canActivate: [guestGuard],
        loadComponent: () => import('./pages/dashboard/dashboard.page').then((m) => m.DashboardPage)
    ),
    (
        path: 'Interests',
        canActivate: [guestGuard],
        loadComponent: () => import('./pages/interests/interests.page').then((m) => m.InterestPage)
    ),
    (
        path: 'admin/change-role',
        canActivate: [guestGuard],
        data: ( roles: ['Admin'] ),
        loadComponent: () => import('./pages/admin-change-role/admin-change-role.page').then((m) => m.AdminChangeRolePage)
    ),
    (
        path: '**'
        redirectTo: 'dashboard'
    )
];
