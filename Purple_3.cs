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
            public int[] Places => places;
            public double[] Marks => marks;
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

            public Participant (string aname, string asurname)
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
                    int place = 1;
                    for (int i = 0; i < participants.Length; i++)
                    {
                        if (i > 0 && Math.Abs(participants[i].Marks[k] - participants[i - 1].Marks[k]) > 0.001)
                        {
                            place = i + 1;
                        }
                        participants[i].places[k] = place;
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Score > array[j + 1].Score)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        if (array[j].Score == array[j + 1].Score)
                        {
                            double s = 0, f = 0;
                            for (int k = 0; k < 7; k++)
                            {
                                if (array[j].Places[k] > array[j].Places[k + 1])
                                {
                                    s = -1;
                                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                                    break;
                                }
                                else if (array[j].Places[k] < array[j].Places[k + 1])
                                {
                                    s = -1;
                                    break;
                                }
                                if (s == -1) break;
                                s += array[j].Places[k];
                                f += array[j].Places[k + 1];
                            }
                            if (s != -1 && s > f)
                                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public static void Print(Participant s)
            {

            }
        }
    }
}
