using System.Text;
using morseovka;

Morseovka morseovka = new Morseovka();

//string text = "Nejkulikatější kulička prorazila velkou hráz";
string text = "-././.---/-.-/..-/.-../../-.-/.-/-/./.---/.../..//-.-/..-/.-../../-.-./-.-/.-//.--./.-./---/.-./.-/--../../.-../.-//...-/./.-../-.-/---/..-//..../.-./.-/--..";

//Console.WriteLine(morseovka.Encode(text));
Console.WriteLine(morseovka.Decode(text));