//////////PROGRAMMA COMPLETO (DA SCRIVERE) PER LA GESTIONE DI UNA RUBRICA CON CONTATTI, CHE INCLUDE:
using Newtonsoft.Json;
/// -utilizzo di classi modello per rappresentare i dati dei contatti e degli ID



/// -utilizzo di classi controller per gestire la logica di business della rubrica

//da lasciare nel file originale Program.cs?????????????
var LastIdController= new LastIdController();
int nextId = LastIdController.GetNextId();
Console.WriteLine($"Il nuovo ID è: {nextId}");



/// -suddivisione dei files in folders di Models, Controllers, Helpers e Data (e invece Services/?????????????)
/// 
/// -utilizzo di una classe statica JSONHelper per semplificare la lettura e scrittura dei file Json
/// 
/// 
/// 

/// 
/// 
/// 
/// 
/// 
/// 
/// -validazione dei dati di input tramite decoratori
/// Il focus di questo programma è sull'organizzazione del codice e sull'utilizzo dei decoratori per validare i dati di input
/// La suddivisione completa delle responsabilità delleclassi modello, controller e helper permette di mantenere il codice pulito, modulare e facilmente manutentibile
/// 

//
///
/// 

