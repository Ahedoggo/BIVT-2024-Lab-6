using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int distance;
            private int[] _marks;

            public string Name => name;
            public string Surname => surname;
            public int Distance => distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, copy.Length);
                    return copy;
                }
            }

            public int Result
            {
                get
                {
                    if (_marks == null || _marks.Length != 5) return 0;
                    int m = 0, n = 0, r = 0;
                    for (int i = 0; i < Marks.Length; i++)
                    {
                        if (Marks[i] < Marks[n]) n = i;
                        if (Marks[i] > Marks[m]) m = i;
                        r += Marks[i];
                    }
                    r -= Marks[n] + Marks[m];
                    r += (Distance - 120) * 2 + 60;
                    if (r < 0) r = 0;
                    return r;
                }
            }

            public Participant(string aname, string asurname)
            {
                distance = 0;
                _marks = new int[5] { 0, 0, 0, 0, 0 };
                name = aname;
                surname = asurname;
            }

            public void Jump(int d, int[] m)
            {
                if (d < 0 || m == null || m.Length != 5) return;
                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i] < 1 || m[i] > 20) return;
                    _marks[i] = m[i];
                    distance = d;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            public static void Print(Participant s)
            {

            }

        }
    }
}

