using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morseovka
{
    internal class Morseovka
    {
        public string Encode(string text)
        {
            string[] PolePismen = CleanUpEncode(text);
            List<string> PrelozeneZnaky = new List<string>();
            for (int i = 0; i < PolePismen.Length; i++)
            {
                PrelozeneZnaky.Add(_textToMorse[PolePismen[i].ToString()] + "/");
            }
            return String.Join("", PrelozeneZnaky.ToArray());
        }

        public string Decode(string text)
        {
            List<string> PrelozeneZnaky = new List<string>();
            string[] SplitnuteZnaky = CleanUpDecode(text);
            for (int i = 0; i < SplitnuteZnaky.Length; i++)
            {
                PrelozeneZnaky.Add(_reversedTextToMorse[SplitnuteZnaky[i].ToString()]);
            }
            string vysledek = "";
            foreach (var item in PrelozeneZnaky)
            {
                vysledek += item;
            }
            return vysledek;
        }


        //
        private string[] CleanUpEncode(string text)
        {
            // Zbaví text diakri
            string normalizedText = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (var x in normalizedText)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(x) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(x);
                }
            }
            string novytext = sb.ToString().ToUpper().Normalize(NormalizationForm.FormC);
            List<string> PolePismen = new List<string>();
            for (int i = 0; i < novytext.Length; i++)
            {
                PolePismen.Add(novytext[i].ToString());
            }
            for (int j = 0; j < PolePismen.Count; j++)
            {
                if (PolePismen[j] == "C" && PolePismen[j+1] == "H")
                {
                    PolePismen[j] = "CH";
                    PolePismen.RemoveAt(j+1);
                }
            }
            return PolePismen.ToArray();
        }


        // Splitne vstup pro dekódování
        private string[] CleanUpDecode(string text)
        {
            return text.Split("/");
        }

        // Obrácený slovník s znaky - Použitý k dekódování
        Dictionary<string, string> _reversedTextToMorse = _textToMorse.ToDictionary(x => x.Value, x => x.Key);

        // Slovník se znaky - Použitý ke kódování
        private static Dictionary<string, string> _textToMorse = new Dictionary<string, string>()
        {
          {" ", ""},
          {"A", ".-"},
          {"B", "-..."},
          {"C", "-.-."},
          {"D", "-.."},
          {"E", "."},
          {"F", "..-."},
          {"G", "--."},
          {"H", "...."},
          {"CH", "----" },
          {"I", ".."},
          {"J", ".---"},
          {"K", "-.-"},
          {"L", ".-.."},
          {"M", "--"},
          {"N", "-."},
          {"O", "---"},
          {"P", ".--."},
          {"Q", "--.-"},
          {"R", ".-."},
          {"S", "..."},
          {"T", "-"},
          {"U", "..-"},
          {"V", "...-"},
          {"W", ".--"},
          {"X", "-..-"},
          {"Y", "-.--"},
          {"Z", "--.."},
          {"1", ".----"},
          {"2", "..---"},
          {"3", "...--"},
          {"4", "....-"},
          {"5", "....."},
          {"6", "-...."},
          {"7", "--..."},
          {"8", "---.."},
          {"9", "----."},
          {"0", "-----"},
          {".", ".-.-.-."},
          {",", "--..--"},
          {"?", "..--.."},
          {"!", "--..-"},
          {";", "-.-.-."},
          {":", "---..."},
          {"@", ".--.-."},
        };
    }
}
