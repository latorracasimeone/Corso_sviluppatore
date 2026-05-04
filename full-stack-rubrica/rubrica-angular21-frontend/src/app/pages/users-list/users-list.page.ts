import { Component, inject, signal, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
// Importa il DTO degli utenti se lo hai creato, altrimenti usa 'any' o crea un'interfaccia
// import { UserStampDto } from '../../models/user.model'; 

@Component({
  selector: 'app-users-list',
  standalone: true, // Lo rendiamo standalone come InterestPage
  // Se aggiungerai form o altre direttive, inseriscile qui in 'imports'
  imports: [], 
  templateUrl: './users-list.page.html',
  styleUrl: './users-list.page.css'
})
export class UsersListPage implements OnInit {

  // Iniezione dei servizi tramite 'inject'
  private readonly authService = inject(AuthService);

  // Stati del componente gestiti con i Signals
  // Sostituisci 'any[]' con 'UserStampDto[]' se hai definito l'interfaccia nel frontend
  readonly users = signal<any[]>([]); 
  readonly isLoading = signal(false);
  readonly errorMessage = signal('');
  
  // Se in futuro vorrai aggiungere la modifica o l'eliminazione degli utenti:
  // readonly successMessage = signal('');
  // readonly editingId = signal<string | null>(null);

  // In Angular è meglio usare ngOnInit invece del costruttore per il caricamento iniziale dei dati
  ngOnInit(): void {
    this.loadUsers();
  }

  // Verifica dei permessi (opzionale lato HTML, ma utile)
  canViewAndEdit(): boolean {
    return this.authService.hasAnyRole(['Admin', 'Editor']);
  }

  loadUsers(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.authService.getAllUsers().subscribe({
      next: (items) => {
        this.users.set(items);
        this.isLoading.set(false);
      },
      error: (error: unknown) => {
        this.isLoading.set(false);
        this.errorMessage.set(
          this.extractErrorMessage(error, 'Impossibile caricare la lista degli utenti')
        );
      }
    });
  }

  // Se deciderai di aggiungere le funzioni Modifica/Elimina in futuro, 
  // potrai inserire qui i metodi startEdit(), deleteEdit(), ecc., esattamente come in InterestsPage.

  // Funzione per il tracking nel ciclo @for dell'HTML
  trackById(_: number, item: any): string {
    return item.id; // Presumendo che l'ID utente sia una stringa
  }

  // Metodo di utilità privato per gli errori
  private extractErrorMessage(error: unknown, fallback: string): string {
    if (error instanceof Error) {
      return error?.message ?? fallback;
    }
    return fallback;
  }
}