import { bootstrapApplication } from '@angular/platform-browser'; //
import { appConfig } from './app/app.config'; //contiene configurazione generale
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
