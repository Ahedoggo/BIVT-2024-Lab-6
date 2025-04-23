using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;
using static Lab_6.Purple_5;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string animal;
            private string charactertrait;
            private string concept;
            
            public string Animal => animal;
            public string CharacterTrait => charactertrait;
            public string Concept => concept;
            private string[] All
            {
                get
                {
                    return new string[] { animal, charactertrait, concept};
                }
            }

            public Response(string a, string ct, string c)
            {
                animal = a;
                charactertrait = ct;
                concept = c;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                int n = 0;
                questionNumber--;
                foreach (var r in responses)
                {
                    if (r.All[questionNumber] != "")
                        n++;
                }
                return n;
            }

            public void Print()
            {
                Console.WriteLine(animal + " " + charactertrait + " " + concept);
            }
        }

        public struct Research
        {
            private string name;
            private Response[] responses;
            public string Name => name;
            public Response[] Responses
            {
                get
                {
                    if (responses == null) return null;
                    var r = new Response[responses.Length];
                    for (int i = 0; i < r.Length; i++)
                        r[i] = responses[i];
                    return r;
                }
            }

            public Research(string aname)
            {
                name = aname;
                responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || responses == null) return;
                var s = new string[3];
                for (int i = 0; i < Math.Min(answers.Length,3);i++)
                {
                    s[i] = answers[i];
                }
                var r = new Response[responses.Length+1];
                Array.Copy(responses,r,responses.Length);
                r[responses.Length] = new Response(s[0], s[1], s[2]);
                responses = r;
            }

            public string[] GetTopResponses(int question)
            {
                if (responses == null || question < 1 || question > 3)
                    return null;
                string[] all = new string[responses.Length];
                for (int i = 0; i < responses.Length; i++)
                {
                    switch (question)
                    {
                        case 1: all[i] = responses[i].Animal; break;
                        case 2: all[i] = responses[i].CharacterTrait; break;
                        case 3: all[i] = responses[i].Concept; break;
                    }
                }

                string[] dif = new string[all.Length];
                int[] counts = new int[all.Length];
                int uniqueCount = 0;

                for (int i = 0; i < all.Length; i++)
                {
                    if (all[i] == null)
                        continue;

                    bool found = false;
                    for (int j = 0; j < uniqueCount; j++)
                    {
                        if (dif[j] == all[i])
                        {
                            counts[j]++;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        dif[uniqueCount] = all[i];
                        counts[uniqueCount] = 1;
                        uniqueCount++;
                    }
                }

                for (int i = 0; i < uniqueCount; i++)
                {
                    for (int j = 0; j < uniqueCount - 1 - i; j++)
                    {
                        if (counts[j] < counts[j+1])
                        {
                            (counts[j], counts[j+1]) = (counts[j + 1], counts[j]);
                            (dif[j+1], dif[j]) = (dif[j], dif[j+1]);
                        }
                    }
                }

                int resultCount = Math.Min(5, uniqueCount);
                string[] result = new string[resultCount];
                for (int i = 0; i < resultCount; i++)
                {
                    result[i] = dif[i];
                }

                return result;
            }

            public void Print()
            {

            }
        }
    }
}
