//LEZIONE 19 CLASS PROGRAM MAIN

//Se vogliamo suddividere il programma in più classi (cioè file separati), possiamo creare un file Program.cs contenente solo il main.

//POSSO USARE IL MAIN IN QUALSIASI PUNTO DEL PROGRAMMA!!! Non più solo sopra le classi (GUARDA riga:75)
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class LastId 
{
    public int Id { get; set; }
}

public static class JsonHelper 
{
    public static void Salva(string path, object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static T Leggi<T>(string path)
    {
        // ATTENZIONE: Qui avevi un errore logico! 
        // Se il file ESISTE, devi leggerlo, non ritornare default.
        if (!File.Exists(path)) 
        {
            return default(T);
        }
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }
}

public class LastIdController 
{
    private readonly string path = "lastId.json";
    private LastId lastIdObj;

    public LastIdController()
    {
        // Sintassi corretta per l'inizializzazione: { Id = 0 }
        lastIdObj = JsonHelper.Leggi<LastId>(path) ?? new LastId { Id = 0 };
    }

    public int GetNextId()
    {
        lastIdObj.Id++;
        JsonHelper.Salva(path, lastIdObj);
        return lastIdObj.Id;
    }
}























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




//NAMESPACES
//Vengono utilizzati per organizzare le classi e i metodi in gruppi logici, evitando conflitti di nomi tra classi con lo stesso nome.
//Un namespace è definito utilizzando la parola chiave "namespace", seguita dal nome dello namespace.
namespace RubricaTelefonica
{
    class LastIdController
    {
        static void Main(string[] args)
        {
            //codice del main
        }
    }
}
//in questo caso program comunica agli altri file che la classe con lo stesso nome, ad esempio Program, possiamo distinguere le due classi utilizzando il namespace
namespace RubricaTelefonica2
{
    class Program
    é
    static void Main(string[] args)
    {
        //codice del main
    }
}
//in questo caso, se vogliamo usare la classe LastIdController del namespace RubricaTelefonica, dobbiamo specificare il namespace completo:
using RubricaTelefonica

class Program
{
    static void Main(string[] args)
    {
        LastIdController controller = new LastIdController();
        //codice main
    }
}

//se voglio mettere il files in folders (cartelle) specifiche che non siano quelle di default posso farlo ma devo specificare il namespace,
//in modo che il compilatore sappia dove trovare le classi.   Se la folder è "Controllers", il namespace potrebbe essere "RubricaTelefonica.Controllers", ad esempio.

//in questo modo, se vogliamo utilizzare le classi LastIdController e LastId del namespace RubricaTelefonica.Controllers e RubricaTelefonica.Models, dobbiamo specificare il namespace completo:
using RubricaTelefonica.Controllers;
using RubricaTelefonica.Models;

//inserire class program...