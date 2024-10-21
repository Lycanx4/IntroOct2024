import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WelcomeComponent } from './components/welcome.component';
import { NavigationComponent } from './components/navigation.component';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <app-navigation />
    <main class="container mx-auto">
      <router-outlet />
    </main>
  `,
  styles: [],
  imports: [RouterOutlet, WelcomeComponent, NavigationComponent],
})
export class AppComponent {}
