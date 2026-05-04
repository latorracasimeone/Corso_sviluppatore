import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { guestGuard } from './core/guards/guest.guard';
import { roleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard',
  },
  {
    path: 'login',
    canActivate: [guestGuard],
    loadComponent: () => import('./pages/login/login.page').then((m) => m.LoginPage), // load component carica le pagine in lazyloagin nel modello standalone di angular
  },
  {
    path: 'register',
    canActivate: [guestGuard],
    loadComponent: () => import('./pages/register/register.page').then((m) => m.RegisterPage),
  },
  {
    path: 'dashboard',
    canActivate: [authGuard],
    loadComponent: () => import('./pages/dashboard/dashboard.page').then((m) => m.DashboardPage),
  },
  {
    path: 'interests',
    canActivate: [authGuard],
    loadComponent: () => import('./pages/interests/interests.page').then((m) => m.InterestsPage),
  },
  {
    path: 'admin/change-role',
    canActivate: [authGuard, roleGuard],
    loadComponent: () =>
      import('./pages/admin-change-role/admin-change-role.page').then((m) => m.AdminChangeRolePage),
  },
  // ECCO LA NUOVA ROTTA UNIFORMATA:
  {
    path: 'users',
    canActivate: [authGuard, roleGuard], // Proteggiamo la pagina
    data: { roles: ['Admin', 'Editor'] }, // Diciamo alla roleGuard chi può entrare
    loadComponent: () => import('./pages/users-list/users-list.page').then((m) => m.UsersListPage),
  },
  // LA ROTTA JOLLY (**) VA SEMPRE PER ULTIMA!
  {
    path: '**',
    redirectTo: 'dashboard',
  },
];
