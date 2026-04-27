import { Injectable, Inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { enviroment } from '../../enviroments/enviroments'; //cambialo in ENVIRONMENT caprone
import { AuthResponse } from '../models/auth-response.model';
import { LoginRequest } from '../models/login.model';
import { RegisterRequest } from '../models/register.model';
import { SessionUser } from '../models/session-user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {}

/*SIGNAL SERVE PER GESTIRE LA SESSIONE ATTUALE DELLO USER*/
readonly currentUser = signal<SessionUser | null>(this.readStoredUser());