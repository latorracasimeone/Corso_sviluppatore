//LEZIONE 14 Metodi Files Folder


// Esempio di percorso assoluto:   (quando scrivo //// significa che son barre di codice da esempio ma che non devono influire nel codice complessivo)
//anche perché non è consigliato l'utilizzo di percorsi assoluti, in quanto possono variare da un computer all'altro e rendere il codice meno portabile.
////string absolutePath = @"C:\Users\Username\Documents\file.txt";

//prova percorso relativo
string relativePath = @"..\..\file.txt";

// Ottenere il nome del file da un percorso
string fileName = Path.GetFileName(relativePath); // Restituisce "testo di prova"
// Ottenere la directory da un percorso
string directory = Path.GetDirectoryName(relativePath); // Restituisce "..\.."
// ottenere l'estensione del file da un percorso
string extension = Path.GetExtension(relativePath); // Restituisce 
// ottenere il nome del file senza estensione da un percorso
string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(relativePath);

string dimmi = Directory.GetCurrentDirectory(); // Restituisce la directory di lavoro corrente
Console.WriteLine($" IL PERCORSO DEL FILE ATTUALE è {dimmi}");

Console.WriteLine($"il nome del file è {fileName}");
Console.WriteLine($"la directory è {directory}");
Console.WriteLine($"l'estensione del file è {extension}");
Console.WriteLine($"il nome del file senza estensione è {fileNameWithoutExtension}");


// Combinare percorsi
string combinedPath = Path.Combine("C:\\Users", "Username", "Documents", "file.txt");
Console.WriteLine(combinedPath); // Stampa "C:\Users\Username\Documents\file.txt"



Console.WriteLine("//CREAZIONE DI FILES!!!!!!!!!!!!!!");
// Creare un file
string path = @"test.txt";
File.WriteAllText(path, "Sono Giapponese!");// Crea un file chiamato "test.txt" e scrive "Sono Giapponese" al suo interno

// Leggere un file
if (File.Exists(path))
{
    string contenuto = File.ReadAllText(path);
    Console.WriteLine(contenuto);
}
else
{
    Console.WriteLine("Il file non esiste.");
}

// Eliminare un file
if (File.Exists(path))
{
    File.Delete(path);  // Elimina il file
}
else
{
    Console.WriteLine("Il file non esiste.");
}

//RIcreazione di un file
//non è necessario riscrivere 'string path = @"test.txt";' perché la variabile 'path' è già stata dichiarata in precedenza e può essere riutilizzata, anche se il file è stato eliminato. La variabile 'path' contiene ancora il percorso del file, quindi puoi semplicemente chiamare nuovamente 'File.WriteAllText(path, "Sono Giapponese!");' per creare un nuovo file con lo stesso nome e scrivere il testo al suo interno.
File.WriteAllText(path, "Sono Giapponese!!");

// Copiare un file
string sourcePath = @"test.txt"; // Assicurati che "test.txt" esista prima di eseguire questo codice
string destinationPath = @"destination.txt";
if (File.Exists(sourcePath))
{
    File.Copy(sourcePath, destinationPath); // Copia il file
}
else
{
    Console.WriteLine("Il file di origine non esiste.");
}

// Rinominare un file
string oldFileName = destinationPath; //si può utilizzare direttamente 'destinationPath' perché contiene già il percorso del file da rinominare
string newFileName = @"newName.txt";
if (File.Exists(oldFileName))
{
    File.Move(oldFileName, newFileName); // Rinomina il file
}
else
{
    Console.WriteLine("Il file da rinominare non esiste.");
}

Console.WriteLine("//INFORMAZIONI SUI FILE!!!!!!!!!!!!!!");
// ottenere informazioni su un file
FileInfo info = new FileInfo(path);
Console.WriteLine(info.Length); // dimensione del file in byte
Console.WriteLine(info.CreationTime); // data di creazione del file
Console.WriteLine(info.LastWriteTime); // data dell'ultima modifica del file
Console.WriteLine(info.Extension); // estensione del file
Console.WriteLine(info.Name); // nome del file con estensione
Console.WriteLine(info.DirectoryName); // percorso della directory che contiene il file

// Scrivere su un file
//non è necessario riscrivere 'string path = @"test.txt";' perché la variabile 'path' è già stata dichiarata in precedenza e può essere riutilizzata, anche se il file è stato eliminato. La variabile 'path' contiene ancora il percorso del file, quindi puoi semplicemente chiamare nuovamente 'File.WriteAllText(path, "Sono Giapponese!");' per creare un nuovo file con lo stesso nome e scrivere il testo al suo interno.
string content = "Calipari è il migliore!"; // Contenuto da scrivere nel file
File.WriteAllText(path, content); // Scrive tutto il testo nel file, sovrascrivendo se esiste già
// oppure
////File.AppendAllText(path, content); // Aggiunge il testo alla fine del file, senza sovrascrivere il contenuto precedente

