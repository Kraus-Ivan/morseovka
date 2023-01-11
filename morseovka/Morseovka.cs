using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morseovka
{
    internal class Morseovka
    {
        /// <summary>
        /// Kóduje text do morseova kódu
        /// </summary>
        /// <param name="text">Vstupní text</param>
        /// <returns>´Morseův kód</returns>
        public string Encode(string text)
        {
            List<string> polePismen = CheckCH(SplitEncode(CleanUpEncode(text)));
            List<string> prelozeneZnaky = new List<string>();
            for (int i = 0; i < polePismen.Count; i++)
            {
                prelozeneZnaky.Add(_textToMorse[polePismen[i].ToString()]);
                if (! (i == polePismen.Count - 1))
                {
                    prelozeneZnaky.Add("/");
                }
            }
            return String.Join("", prelozeneZnaky.ToArray());
        }

        /// <summary>
        /// Dekóduje morseovův kód do textu
        /// </summary>
        /// <param name="text">Vstupní morseův kód</param>
        /// <returns>Přeložený text</returns>
        public string Decode(string text)
        {
            List<string> prelozeneZnaky = new List<string>();
            string[] splitnuteZnaky = text.Split("/");
            for (int i = 0; i < splitnuteZnaky.Length; i++)
            {
                prelozeneZnaky.Add(_reversedTextToMorse[splitnuteZnaky[i].ToString()]);
            }
            return String.Join("", prelozeneZnaky.ToArray());
        }

        /// <summary>
        /// Zbaví text diakritiky a převede na velká písmena
        /// </summary>
        /// <param name="text">Vstupní text</param>
        /// <returns>Vrací očištěný text</returns>
        private string CleanUpEncode(string text)
        {
            string normalizedText = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (var x in normalizedText)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(x) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(x);
                }
            }
            return sb.ToString().ToUpper().Normalize(NormalizationForm.FormC);
        }
        
        /// <summary>
        /// Kontroluje výskyt znaku CH
        /// </summary>
        /// <param name="poleZnaku">Vstupní pole se znaky</param>
        /// <returns>Zkontrolované pole znaků</returns>
        private List<string> CheckCH(List<string> poleZnaku)
        {
            for (int j = 0; j < poleZnaku.Count; j++)
            {
                if (poleZnaku[j] == "C" && poleZnaku[j + 1] == "H")
                {
                    poleZnaku[j] = "CH";
                    poleZnaku.RemoveAt(j + 1);
                }
            }
            return poleZnaku;
        }

        /// <summary>
        /// Rozdělí text na jednotlivá písmena
        /// </summary>
        /// <param name="text">Vstupní text</param>
        /// <returns>Pole s jednotlivými znaky</returns>
        private List<string> SplitEncode(string text)
        {
            List<string> poleZnaku = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                poleZnaku.Add(text[i].ToString());
            }
            return poleZnaku;
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
