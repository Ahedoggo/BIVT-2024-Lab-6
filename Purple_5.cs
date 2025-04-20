using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;
using static Lab_6.Purple_5;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Responce
        {
            private string animal;
            private string charactertrait;
            private string concept;
            
            public string Animal => animal;
            public string CharacterTrait => charactertrait;
            public string Concept => concept;
            public string[] All//; => [animal, charactertrait, concept];
            {
                get
                {
                    return new string[] { animal, charactertrait, concept};
                }
            }

            public Responce(string a, string ct, string c)
            {
                animal = a;
                charactertrait = ct;
                concept = c;
            }

            public int CountVotes(Responce[] responses, int questionNumber)
            {
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                int n = 0;
                questionNumber--;
                foreach (var r in responses)
                {
                    if (r.All[questionNumber] == All[questionNumber])
                        n++;
                }
                return n;
            }
        }

        public struct Research
        {
            private string name;
            private Responce[] responses;

            public string Name => name;
            public Responce[] Responses
            {
                get
                {
                    if (responses == null) return null;
                    var r = new Responce[responses.Length];
                    for (int i = 0; i < r.Length; i++)
                        r[i] = responses[i];
                    return r;
                }
            }

            public Research(string aname)
            {
                name = aname;
                responses = new Responce[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || responses == null) return;
                var s = new string[3];
                for (int i = 0; i < Math.Min(answers.Length,3);i++)
                {
                    s[i] = answers[i];
                }
                var r = new Responce[responses.Length+1];
                Array.Copy(responses,r,responses.Length);
                r[responses.Length] = new Responce(s[0], s[1], s[2]);
                responses = r;
            }

            public struct arr
            { 
                public string top;
                public int ind;
            }

            public string[] GetTopResponses(int question)
            {
                if (responses == null) return null;
                question--;
                var a = new arr[5];
                for (int i = 0; i < 5;i++)
                {
                    a[i].top = "-";
                    a[i].ind = 0;
                }
                int n = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                        if (a[j].top == responses[i].All[question])
                            n = 1;
                    if (n == 1)
                    {
                        n = 0;
                        continue;
                    }
                    string s = responses[i].All[question];
                    int k = 0;
                    for (int j = 0; j < responses.Length; j++)
                        if (responses[j].All[question] == s)
                            k++;
                    var b = new arr[6];
                    Array.Copy(a, b, a.Length);
                    b[5].top = s;
                    b[5].ind = k;
                    for (int t = 0; t < 6; t++)
                    {
                        for (int j = 0; j < 5 - t; j++)
                        {
                            if (b[j].ind < b[j + 1].ind)
                                (b[j], b[j + 1]) = (b[j + 1], b[j]);
                        }
                    }
                    Array.Copy(b, a, a.Length);
                }
                return [a[0].top, a[1].top, a[2].top, a[3].top, a[4].top];
            }

            public void Print()
            {

            }
        }
    }
}
