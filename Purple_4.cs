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

            public string Name => name;
            public string Surname => surname;
            public double Time => time;

            public Sportsman(string aname, string asurname)
            {
                name = aname;
                surname = asurname;
                time = -1;
            }

            public void Run(double t)
            {
                if (time != -1) return;
                time = t;
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
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    for (int j = 0; j < sportsmen.Length - 1 - i; j++)
                    {
                        if (sportsmen[j].Time > sportsmen[j + 1].Time)
                            (sportsmen[j], sportsmen[j + 1]) = (sportsmen[j + 1], sportsmen[j]);
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                var fin = new Group("Финалисты");
                fin.Add(group1);
                fin.Add(group2);

                fin.Sort();

                return fin;
            }

            public void Print()
            {

            }
        }
    }
}
