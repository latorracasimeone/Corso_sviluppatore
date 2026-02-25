

// Elencare i file in una directory
if (Directory.Exists(dir))
{
    string[] files = Directory.GetFiles(dir); // Ottiene un array di stringhe con i percorsi dei file nella directory
    foreach (string file in files)
    {
        Console.WriteLine(file); // Stampa il percorso di ogni file
    }
}
else
{
    Console.WriteLine("La directory non esiste.");
}

// Elencare le sottodirectory in una directory
if (Directory.Exists(dir))
{
    string[] subdirs = Directory.GetDirectories(dir); // Ottiene un array di stringhe con i percorsi delle sottodirectory nella directory
    foreach (string subdir in subdirs)
    {
        Console.WriteLine(subdir); // Stampa il percorso di ogni sottodirectory
    }
}
else
{
    Console.WriteLine("La directory non esiste.");
}
