using System.Text;
using morseovka;

Morseovka morseovka = new Morseovka();
string text = "Šílená chlupatá veverka";
//string text = ".../../.-.././-./.-//----/.-../..-/.--./.-/-/.-//...-/./...-/./.-./-.-/.-/";
string vysledek = morseovka.Encode(text);
Console.WriteLine(vysledek);

//Console.WriteLine(morseovka.Decode(text));