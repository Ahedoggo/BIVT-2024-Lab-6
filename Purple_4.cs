using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string name;
            private string surname;
            private double time;
            private bool flag;

            public string Name => name;
            public string Surname => surname;
            public double Time => time;

            public Sportsman(string aname, string asurname)
            {
                name = aname;
                surname = asurname;
                time = 0;
            }

            public void Run(double t)
            {
                if (flag) return;
                time = t;
                flag = true;
            }
        }

        public struct Group
        {
            private string name;
            private Sportsman[] sportsmen;

            public string Name => name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (sportsmen == null) return null;

                    var _sportsmen = new Sportsman[sportsmen.Length];
                    Array.Copy(sportsmen, _sportsmen, sportsmen.Length);
                    return _sportsmen;
                }
            }

            public Group(string aname)
            {
                name = aname;
                sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                name = group.Name;
                if (group.Sportsmen == null)
                    sportsmen= new Sportsman[0];
                else
                {
                    sportsmen = new Sportsman[group.Sportsmen.Length];
                    for(int i = 0; i < group.Sportsmen.Length; i++)
                        sportsmen[i] = group.Sportsmen[i];
                }
            }

            public void Add(Sportsman man)
            {
                if (sportsmen == null) return;
                var s = new Sportsman[sportsmen.Length +1];
                int i = 0;
                for (; i < sportsmen.Length; i++)
                    s[i] = sportsmen[i];
                s[i] = man;
                sportsmen = s;
            }
            public void Add(Sportsman[] men)
            {
                if (sportsmen == null || men == null) return;
                var s = new Sportsman[sportsmen.Length + men.Length];
                int i = 0;
                for (; i < sportsmen.Length; i++)
                    s[i] = sportsmen[i];
                for (int j = 0; j < men.Length; j++)
                {
                    s[i + j] = men[j];
                }

                sportsmen = s;
            }
            public void Add(Group gr)
            {
                if (sportsmen == null || gr.Sportsmen == null) return;
                Add(gr.Sportsmen);
            }

            public void Sort()
            {
                if (sportsmen == null) return;
                Array.Sort(sportsmen, (f, s) =>
                {
                    double d = f.Time - s.Time;
                    if (d < 0) return -1;
                    else if (d > 0) return 1;
                    else return 0;
                });
            }

            public static Group Merge(Group group1, Group group2)
            {
                var fin = new Group("Финалисты");
                var a = group1.sportsmen;
                var b = group2.sportsmen;
                fin.sportsmen = new Sportsman[a.Length + b.Length];
                int i = 0, j = 0, k = 0;
                while (i < a.Length && j < b.Length)
                {
                    if (a[i].Time <= b[j].Time)
                    {
                        fin.sportsmen[k++] = a[i++];
                    }
                    else fin.sportsmen[k++] = b[j++];
                }
                while (i < a.Length) fin.sportsmen[k++] = a[i++];
                while (j < b.Length) fin.sportsmen[k++] = b[j++];

                //fin.Add(group1);
                //fin.Add(group2);
                //fin.Sort();

                return fin;
            }

            public void Print()
            {
                Console.WriteLine($"Group: {Name}");
                foreach (var sportsman in sportsmen)
                {
                    Console.WriteLine(sportsman.Name + " " + sportsman.Surname + " " + sportsman.Time);
                }
            }
        }
    }
}
