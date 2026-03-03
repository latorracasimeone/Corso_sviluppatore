//LEZIONE 19 CLASS PROGRAM MAIN

//Se vogliamo suddividere il programma in più classi (cioè file separati), possiamo creare un file Program.cs contenente solo il main.

//POSSO USARE IL MAIN IN QUALSIASI PUNTO DEL PROGRAMMA!!! Non più solo sopra le classi (GUARDA riga:75)




//Esempio di Blocco Main:
class Program
{
    //la firma
    static void Main(string[] args)
    {
        var lastIdController = new LastIdController();
        int nextId = lastIdController.GetNextId();
        Console.WriteLine($"Il nuovo ID è: {nextId}");
    }
}
//NON è obbligatorio avere un metodo main, ma è necessario se vogliamo suddividere l'applicazione o il porgramma in più classi e file, altrimenti non saprebbe da dove iniziare e restituisce un errore di posizionamento del codice



//POSSIBILITà DI SUDDIVIDERE L'APPLICAZIONE IN PIù CARTELLE (es: Controllers/) E FILE (es: JsonHelper.cs). IMPORTANTE: i file .cs devono avere lo stesso nome delle classi!!

