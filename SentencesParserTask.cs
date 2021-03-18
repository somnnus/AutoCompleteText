using System.Collections.Generic;

namespace TextAnalysis
{
    public static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            
            
            var nums = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' }); // разбили на предложения
            
            foreach (string sentence in nums)
            {
                if (sentence.Length == 0) continue;
                List<string> NormalWords = new List<string>();
                var words = sentence.Split(new char[] { '^', '#', '$', '-', '+', '1', '=', ' ', '\t', '\n', '\r', '.', ',', ';', ':', '(', ')', '?', '-'}, System.StringSplitOptions.RemoveEmptyEntries);
                // разбили на слова
                foreach (string word in words)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (!char.IsLetter(word[i]) && word[i] != '\'') break; // отсекаем некорректные слова
                        else if (i == word.Length - 1) NormalWords.Add(word.ToLower()); // меняем заглавные буквы на строчные
                    }
                }
                sentencesList.Add(NormalWords); // заносим слова в list
            }
            return sentencesList;
        }
    }
}