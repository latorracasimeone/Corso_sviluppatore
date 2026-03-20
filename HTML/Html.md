# HTML
l'html è un linguaggio di markup utilizzato per creare pagine web. Esso definisce la struttura e il contenuto di una pagina web utilizzando una serie di attributi.
## Tag
Un tag è un elemento di base dell'html, che viene utilizzato per definire la struttura e il contenuto di una pagina web. I tag sono racchiusi tra parentesi angolari < > e possono essere di apertura o di chiusura.

Esempio di tag di apertura e di chiusura:
```html
<p>Questo è un paragrafo.</p>
```
I tag vanno messi in ordine opposto, tipo se abbiamo un paragrafo con un grassetto dentro, il tag di chiusura del paragrafo va dopo il tag di chiusura del grassetto:
```html
<p><b>paragrafo</b></p>
```
e non così:
```html
NON COSì!!!!!!!!

<p><b>paragrafo</p></b>
```
Cioè l'ultimo aperto è il primo a chiudersi, come in matematica con {[()]} o su whatsapp per grassetto e corsivo _*sas*_


> Alcuni tag hanno un valore semantico, cioè indicano al browser ed ai motori di ricerca il significato del contenuto, ad esempio <h1> indica un titolo principale, mentre <strong> indica un testo importante


Altri tag invece sono utilizzati principalmente per la formattazione del testo, come <b> per il grassetto e <i> per il corsivo.

## Attributi
Gli attributi sono utilizzati per fornire ulteriori informazioni sui tag. Gli attributi sono scritti all'interno del tag di apertura e sono composti da un nome e da un valore.

Esempio di tag con attributo:
```html
<p class="testo">Questo è un paragrafo.</p>
```
- __P__ è il nome del tag
- **class** è il nome dell'attributo
- **"testo"** è il valore dell'attributo

# Pagina HTML
La struttura di una pagina HTML è composta da diversi elementi, tra cui head e body.
- **Head** contiene informazioni sulla pagina, come il titolo e i link ai file CSS e JavaScript
- **Body** contiene il contenuto della pagina, come testo, immagini e altri elementi.

Esempio di pagina base HTML:
```html
<!DOCTYPE html>
<html>
    <head>
        <title>La mia pagina web</title>
    </head>
    <body>
        <h1>Benvenuti nella mia pagina web</h1>
        <p>Questo è un paragrafo di esempio</p>
    </body>
<html>
```
i commenti si scrivono così
```html
<!-- Questo è un commento in HTML -->
```
## HEAD
Generalmente nell'head si mettono le informazioni riguardanti:
- Il titolo della pagina
- I link ai file CSS
- Le indicazioni riguardanti il viewport per la responsività
- Le indicazioni sulla localizzazione della pagina
- Le indicazioni sulla codifica dei caratteri della pagina
Quindi un esempio completo di headh potrebbe essere:
```html
<head>
    <!-- Informazioni sulla pagina -->
     <title>La mia pagina web</title>
     <link rel="stylesheet" href="style.css">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <meta name="language" content="it">
     <meta charset="UTF-8">
</head>
```

