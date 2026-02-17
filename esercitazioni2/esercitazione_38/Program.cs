//RANDOM
Random randommino = new Random();
// il random genera i numeri in un intervallo semi-aperto, cioè include il numero minimo ma esclude il numero massimo
int numeroCasuale = randommino.Next(1, 1021); //da 1 a 1020
int numCasSenzaMinimo = randommino.Next(196);//tra 0 e 195
int numCasTentativoNegativo = randommino.Next(-3, 2);
double numDecimaleDettoDoubleCasuale = randommino.Next();//da 0.0 (incluso) a 1.0 (escluso)
double numDecGrande = randommino.Next(1, 11);//prova da 1.0 a 11.0 (escluso)

bool valBooleanoCas = randommino.Next(1) == 0;








Console.WriteLine($"Il numero casuale è:{numCasSenzaMinimo}");
Console.WriteLine($"Il numero casuale è:{numeroCasuale}");
Console.WriteLine($"il tuo tentativo negativo è:{numCasTentativoNegativo}");
Console.WriteLine($"decimale casuaLE:{numDecimaleDettoDoubleCasuale}");
Console.WriteLine($"decimale fino a 11 escluso:{numDecGrande}!");

Console.WriteLine($"booleano come da istruzioni: {valBooleanoCas}");
