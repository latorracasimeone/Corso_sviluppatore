import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { NavBarComponent } from './shared/components/navbar/navbar.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, NavBarComponent],
    template: `
    <app-navbar></app-navbar>
    <main class="container page">
     <router-outlet></router-outlet>
    </main>
    `
})
export class AppComponent{}