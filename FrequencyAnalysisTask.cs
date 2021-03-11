using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string,string>();
            var dict = new Dictionary<string, Dictionary<string, int>>();
            string union = "";
            for(int i = 0; i < text.Count-1; i++)
            {
                for (int j = 0; j < text[i].Count-1; j++)
                {
                    if (j + 1 < text[i].Count)
                    {
                        string word1 = text[i][j];
                        string word2 = text[i][j+1];
                        if (union != "")
                        {
                            if (!dict.ContainsKey(union))
                            {
                                dict.Add(union, new Dictionary<string, int>());
                                dict[union].Add(word2, 1);
                            }
                            else
                            {
                                if (dict[union].ContainsKey(word2))
                                {
                                    dict[union][word2]++;
                                }
                                else
                                {
                                    dict[union].Add(word2, 1);
                                }
                            }
                        }
                        if (!dict.ContainsKey(word1))
                        {
                            dict.Add(word1, new Dictionary<string, int>());
                            if (j + 1 < text[i].Count)
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

                    }



                }
            }
            for(int i = 0; i < dict.Count; i++)
            {
                
              

            }

            //...
            return result;
        }
   }
}