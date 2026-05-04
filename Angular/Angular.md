# Angular
SEGUI DOCUMENTO SU GEMINI PER INSTALLARE A CASA DOPO TENTATIVI POSTMAN!!!!!!!!!!!!!!!!!!!!
`RECUPERARE APPUNTI ASSENZA!!!!!!! `

# COMANDI
```git bash
ng serve --proxy-config proxy.conf.json 
```
ma noi usiamo `npm start` impostato in package.json come il ng serve precedente

ng serve -o per aprire direttamente il collegamento sul browser





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