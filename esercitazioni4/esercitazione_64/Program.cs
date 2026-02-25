Console.WriteLine("Scrivi il nome di una cartella contenuta in Data:");
string selectedFolder = Console.ReadLine();

string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
string selectedFolderPath = Path.Combine(dataPath, selectedFolder);
string backupFolderPath = CreateBackupFolder(dataPath);

// Elenco le cartelle all'interno della cartella Data
ListFolders(dataPath);

// Elenco i file e le sottodirectory presenti nella cartella selezionata
ListFilesAndSubdirectories(selectedFolderPath);
// Stampo le informazioni sui file e sulle directory elencati
PrintFileAndDirectoryInfo(selectedFolderPath);

// Copio tutti i file presenti nella cartella selezionata mantenendo la struttura delle sottodirectory
CopyFilesWithSubdirectories(selectedFolderPath, backupFolderPath);
// Sposto i files copiati dentro cartelle divisi per estensione
MoveFilesByExtension(backupFolderPath);
// Elimino i file originali dopo averli copiati
// DeleteOriginalFiles(selectedFolderPath);
// Funzione per elencare le cartelle all'interno della cartella Data
void ListFolders(string path)
{
    if (Directory.Exists(path))
    {
        string[] folders = Directory.GetDirectories(path);
        foreach (string folder in folders)
        {
            Console.WriteLine(folder);
        }
    }
    else
    {
        Console.WriteLine("La cartella Data non esiste.");
    }
}
// Funzione per elencare i file e le sottodirectory presenti in una cartella selezionata
void ListFilesAndSubdirectories(string path)
{
    if (Directory.Exists(path))
    {
        string[] files = Directory.GetFiles(path);
        string[] subdirs = Directory.GetDirectories(path);
        Console.WriteLine("Files:");
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
        Console.WriteLine("Subdirectories:");
        foreach (string subdir in subdirs)
        {
            Console.WriteLine(subdir);
        }
    }
    else
    {
        Console.WriteLine("La cartella selezionata non esiste.");
    }
}
// Funzione per stampare le informazioni sui file e sulle directory
void PrintFileAndDirectoryInfo(string path)
{
    if (File.Exists(path))
    {
        FileInfo info = new FileInfo(path);
        Console.WriteLine($"File: {info.Name}");
        Console.WriteLine($"Size: {info.Length} bytes");
        Console.WriteLine($"Created: {info.CreationTime}");
        Console.WriteLine($"Last Modified: {info.LastWriteTime}");
        Console.WriteLine($"Extension: {info.Extension}");
    }
    else if (Directory.Exists(path))
    {
        DirectoryInfo info = new DirectoryInfo(path);
        Console.WriteLine($"Directory: {info.Name}");
        Console.WriteLine($"Created: {info.CreationTime}");
        Console.WriteLine($"Last Modified: {info.LastWriteTime}");
    }
    else
    {
        Console.WriteLine("Il percorso specificato non esiste.");
    }
}
// Funzione per creare una cartella di backup con il timestamp
string CreateBackupFolder(string basePath)
{
    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
    string backupFolderName = $"Data_Backup_{timestamp}";
    string backupFolderPath = Path.Combine(basePath, backupFolderName);
    Directory.CreateDirectory(backupFolderPath);
    return backupFolderPath;
}
// oppure senza usare la ricorsività, utilizzando Directory.GetFiles con SearchOption.AllDirectories
void CopyFilesWithSubdirectories(string sourcePath, string destinationPath)
{
    if (Directory.Exists(sourcePath))
    {
        string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            string relativePath = Path.GetRelativePath(sourcePath, file);
            string destinationFilePath = Path.Combine(destinationPath, relativePath);
            Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
            File.Copy(file, destinationFilePath, false);
        }
    }
    else
    {
        Console.WriteLine("La cartella di origine non esiste.");
    }
}
// Funzione per spostare i file copiati dentro cartelle divisi per estensione
void MoveFilesByExtension(string sourcePath)
{
    if (Directory.Exists(sourcePath))
    {
        string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            string destinationDir = Path.Combine(sourcePath, extension);
            Directory.CreateDirectory(destinationDir);
            string destinationPath = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Move(file, destinationPath);
        }
    }
    else
    {
        Console.WriteLine("La cartella di origine non esiste.");
    }
}
// Funzione per eliminare i file originali dopo averli copiati
void DeleteOriginalFiles(string path)
{
    if (Directory.Exists(path))
    {
        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            File.Delete(file);
        }
    }
    else
    {
        Console.WriteLine("La cartella specificata non esiste.");
    }
}