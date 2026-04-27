# Angular
SEGUI DOCUMENTO SU GEMINI PER INSTALLARE A CASA DOPO TENTATIVI POSTMAN!!!!!!!!!!!!!!!!!!!!
`RECUPERARE APPUNTI ASSENZA!!!!!!! `

# COMANDI
```git bash
ng serve --proxy-config proxy.conf.json 
```
ma noi usiamo `npm start`

## PARTE 3 - CREAZIONE DEL PROGETTO ANGULAR 21
### 9. Come creare il progetto nel modo giusto
Per ricreare un progetto coerente con quello che hai caricato, usa un comando come questo:
```git bash
ng new rubrica-angular21-frontend --routing --standalone --style=css --
```

## PARTE 4 ??

## PARTE 5 - Struttura delle cartelle
### 14. Struttura corretta del frontend
Nel progetto caricato la struttura è:
```git bash
src/app
core
guards
interceptors
models
pages
services
shared
components
```
questa struttura è corretta perché separe responsabilità diverse.
### 15. A cosa serve ogni cartella
### models
Contiene solo interfacce TypeScript

Serve per descrivere la forma dei dati.

Esempi:
- login.model.ts
- register.model.ts
- auth-response.model.ts
- interest.model.ts
- change-user-role.model.ts
- sessione-user.model.ts
### services
Contiene la logica HTTP.

Qui fai:
- chiamate al backend
- logica riusabile collegata ai dati
- sessione utente
Esempi:
- auth.service.ts
- interest.service.ts
- admin-users.service.ts
### pages
Contiene le schermate vere:
- login
- register
- dashboard
- interests
- admin-change-role
### core
Contiene infrastruttura applicativa globale:
- guard
- interceptor
### shared
Contiene componenti riusabili.

Nel tuo caso:
- navbar
## PARTE 6 - Generare i file giusti con Angular CLI
### 16. Comandi per generare navbar, pagine, servizi e sicurezza
Dopo ` ng new`, puoi generare la base del progetto così.
### Navbar condivisa
```git bash

```
### Pagine
```git bash
ng generate component pages/login --type=page --skip-tests
ng generate component pages/register --type=page --skip-tests
ng generate component pages/dashboard --type=page --skip-tests
ng generate component pages/interests --type=page --skip-tests
ng generate component pages/admin-change-role --type=page --skip-tests
```
### Services
```git bash
ng generate service services/auth --skip-tests
ng generate service services/interest --skip-tests
ng generate service services/admin-users --skip-tests
```
### Guard
```git bash

```




# appunti
### proxy.conf.json
```git bash
{
    "/api": {
        "target": "http://localhost:5062", 
        "secure": false,
        "changeOrigin": true,
        "logLevel": "debug"
    }
}
```
contiene secure:false perché non abbiamo una certificazione di sicurezza per farlo funzionare nemmeno in locale solo per testarlo, quindi dobbiamo scriverlo per farlo partie comunque con angular.

Normalmente su target c'è il sito del dominio e non localhost, ovviamente. 

Collegato con:
### enviroment.ts
```git bash
export const enviroment = {
    production: false,
    apiBaseUrl: '/api'
};
//TUTTE LE RICHIESTE (come i controller) CHE INIZIANO CON /api VENGONO INOLTRATI A localhost SU proxy.conf.json
```


# DA RIGUARDARE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
- perché node in mezzo a types???????
```git bash
/* To learn more about Typescript configuration file: https://www.typescriptlang.org/docs/handbook/tsconfig-json.html. */
/* To learn more about Angular compiler options: https://angular.dev/reference/configs/angular-compiler-options. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/app",
    "types": [
      "node"
    ]
  },
  "include": [
    "src/**/*.ts"
  ],
  "exclude": [
    "src/**/*.spec.ts"
  ]
}
```