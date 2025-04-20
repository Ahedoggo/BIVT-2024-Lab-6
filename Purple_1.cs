using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private double[] coefs;
            private int[,] marks;
            public string Name => name;
            public string Surname => surname;
            public double[] Coefs
            {
                get
                {
                    if (coefs == null || coefs.Length == 0) return null;
                    double[] _coefs = new double[coefs.Length];
                    Array.Copy(coefs, _coefs, coefs.Length);
                    return _coefs;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (marks == null || marks.Length == 0) return null;
                    int[,] _marks = new int[marks.GetLength(0), marks.GetLength(1)];
                    Array.Copy(marks, _marks, marks.Length);
                    return _marks;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (marks == null || coefs == null) return 0;
                    double total = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        double s = 0;
                        int m = 0, n = 0;
                        for (int j = 0; j < 7; j++)
                        {
                            if (marks[i, j] > marks[i, m]) m = j;
                            if (marks[i, j] < marks[i, n]) n = j;
                            s += marks[i, j];
                        }
                        s -= marks[i, n] + marks[i, m];
                        s *= coefs[i];
                        total += s;
                    }
                    return total;
                }
            }

            public Participant(string pname, string psurname)
            {
                name = pname;
                surname = psurname;
                coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                marks = new int[4, 7] {{ 0, 0, 0, 0,0,0,0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
            }
            public void SetCriterias(double[] _coefs)
            {
                if (_coefs == null || _coefs.Length != 4 || coefs == null || coefs.Length == 0) { return; }
                for (int i = 0; i < _coefs.Length; i++)
                {
                    if (_coefs[i] < 2.5 || _coefs[i] > 3.5) return;
                    coefs[i] = _coefs[i];
                }
            }

            public void Jump(int[] _marks)
            {
                if (_marks == null || _marks.Length != 7 || marks == null) { return; }
                int a = -1;
                for (int i = 0; i < 4; i++)
                {
                    bool e = true;
                    for (int j = 0; j < 7; j++)
                    {
                        if (marks[i, j] != 0)
                        {
                            e = false;
                            break;
                        }
                    }
                    if (e)
                    {
                        a = i;
                        break;
                    }
                }
                if (a == -1) { return; }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] < 1 || _marks[i] > 6) return;
                    marks[a, i] = _marks[i];
                }
            }


            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
