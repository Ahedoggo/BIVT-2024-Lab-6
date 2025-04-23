


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private double[] marks;
            private int[] places;
            private int num = 0;

            public string Name => name;
            public string Surname => surname;
            public int[] Places
            {
                get
                {
                    if (places == null) return default(int[]);
                    int[] arr = new int[places.Length];
                    Array.Copy(places, arr, places.Length);
                    return arr;
                }
            }
            public double[] Marks
            {
                get
                {
                    if (marks == null) return default(double[]);
                    double[] arr = new double[marks.Length];
                    Array.Copy(marks, arr, marks.Length);
                    return arr;
                }
            }
            public int Score
            {
                get
                {
                    if (places == null) return 0;
                    int r = 0;
                    foreach (int i in places)
                        r += i;
                    return r;
                }
            }

            public Participant(string aname, string asurname)
            {
                name = aname;
                surname = asurname;
                marks = new double[7];
                places = new int[7];
            }

            public void Evaluate(double result)
            {
                if (result < 0 || result > 6 || num == 7) return;
                marks[num] = result;
                num++;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                for (int k = 0; k < 7; k++)
                {
                    for (int i = 0; i < participants.Length; i++)
                    {
                        for (int j = 0; j < participants.Length - 1 - i; j++)
                        {
                            if (participants[j].Marks[k] < participants[j + 1].Marks[k])
                                (participants[j], participants[j + 1]) = (participants[j + 1], participants[j]);
                        }
                    }
                    for (int i = 0; i < participants.Length; i++)
                    {
                        participants[i].places[k] = i+1;
                    }
                    
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (f, s) =>
                {
                    if (f.Score == s.Score)
                    {
                        int m = 0, n = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            if (f.Places[i] < f.Places[m]) m = i;
                            if (s.Places[i] < s.Places[n]) n = i;
                        }
                        if (f.Places[m] < s.Places[n]) return -1;  
                        if (f.Places[m] > s.Places[n]) return 1;   
                        if (f.Places[m] == s.Places[n])
                        {
                            double a = 0, b = 0;
                            for (int i = 0; i < 7; i++)
                            {
                                a += f.Marks[i];
                                b += s.Marks[i];
                            }
                            if (a > b) return -1; 
                            if (a < b) return 1;  
                            return 0;
                        }
                    }
                    if (f.Score < s.Score) return -1;  
                    if (f.Score > s.Score) return 1;  
                    return 0;                         
                });
            }
            public static void Print(Participant s)
            {
                Console.WriteLine($"Name: {s.Name}, Surname: {s.Surname}, Score: {s.Score}");
                Console.WriteLine("Marks: " + string.Join(", ", s.Marks));
                Console.WriteLine("Places: " + string.Join(", ", s.Places));
            }
        }
    }
}
