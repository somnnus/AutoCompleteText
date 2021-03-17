using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            int i = 0;
            bool phraseFilled = true; //идентификатор того, что фраза заполняется
            while (phraseFilled && i < wordsCount)
            {
                var parsedPhraseBeginning = phraseBeginning.Split(' ');
                int n = parsedPhraseBeginning.Length;
                if (n >= 2)
                {
                    var phraseEnd = (from item in nextWords where item.Key == (parsedPhraseBeginning[n - 2] + " " + parsedPhraseBeginning[n - 1]) select item.Value).FirstOrDefault();
                    if (phraseEnd != null)
                    {
                        phraseBeginning += " " + phraseEnd;
                        i++;
                    }
                    else
                    {
                        phraseEnd = (from item in nextWords where item.Key == parsedPhraseBeginning[n - 1] select item.Value).FirstOrDefault();
                        if (phraseEnd != null)
                        {
                            phraseBeginning += " " + phraseEnd;
                            i++;
                        }
                        else
                            phraseFilled = false;
                    }
                }
                else
                if (n == 1)
                {
                    var phraseEnd = (from item in nextWords where item.Key == parsedPhraseBeginning[n - 1] select item.Value).FirstOrDefault();
                    if (phraseEnd != null)
                    {
                        phraseBeginning += " " + phraseEnd;
                        i++;
                    }
                    else
                        phraseFilled = false;
                }
            }
            return phraseBeginning;
        }
    }
}