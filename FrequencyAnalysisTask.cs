using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string,string>();
            var dict = new Dictionary<string, Dictionary<string, int>>();
            string union = "";            
            for(int i = 0; i < text.Count; i++)
            {
                for(int j = 0; j < text[i].Count; j++)
                {
                    if (j + 1 < text[i].Count)
                    {
                        string word1 = text[i][j];
                        string word2 = text[i][j + 1];
                        if (!dict.ContainsKey(word1))
                        {
                            dict.Add(word1, new Dictionary<string, int>());
                            dict[word1].Add(word2, 1);
                        }
                        else
                        {
                            if (dict[word1].ContainsKey(word2))
                            {
                                dict[word1][word2]++;
                            }
                            else
                            {
                                dict[word1].Add(word2, 1);
                            }
                        }
                        union = word1 + " " + word2;
                        if (j + 2 < text[i].Count)
                        {
                            string word3 = text[i][j+2];
                            if (!dict.ContainsKey(union))
                            {
                                dict.Add(union, new Dictionary<string, int>());
                                dict[union].Add(word3, 1);
                            }
                            else
                            {
                                if (dict[union].ContainsKey(word3))
                                {
                                    dict[union][word3]++;
                                }
                                else
                                {
                                    dict[union].Add(word3, 1);
                                }
                            }
                        }
                    }
                }
            }
            foreach(var twoAndThreeGramm in dict)
            {
                var newKey = twoAndThreeGramm.Key;
                Dictionary<string, int> newValue = twoAndThreeGramm.Value;
                var newDict = newValue.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                List<string> list = new List<string>();
               // list.Add(newDict.First().Key);
                int freq = newDict.First().Value;

                foreach(var item in newDict)
                {
                    if (item.Value == freq)
                    {
                        list.Add(item.Key);
                    }
                    else
                    {
                        break;
                    }
                }

                    string word = list[0];
                    foreach (var item in list)
                    {
                        if (string.CompareOrdinal(word, item) < 0)
                        {
                            continue;
                        }
                        else
                        {
                            word = item;
                        }
                    }
                    result.Add(newKey, word);
                

            }

            
            return result;
        }
   }
}