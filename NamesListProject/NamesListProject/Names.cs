using System;
using System.Collections.Generic;
namespace NamesListProject
{
    public class Names
    {
        private List<string> names;

        public string this[int index]
        {
            get 
            {
                if (index < names.Count)
                {
                    return names[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index < names.Count)
                {
                    names[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public string this[string index]
        {
            get
            {
                string lookedUp = string.Empty;
                bool found = false;
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i] == index)
                    {
                        found = true;
                        lookedUp = names[i];
                    }
                }
                if (!found)
                {
                    throw new NoSuchNameException("Nu a fost gasit acest nume!");
                }
                return lookedUp;
            }
        }

        public Names()
        {
            names = new List<string>();
            names.Add("Nadia Comaneci");
        }

        public void Add(string newName)
        {
            names.Add(newName);
        }

        public void Print()
        {
            foreach (var name in names)
            {
                Console.WriteLine(name + ", ");
            }
            Console.WriteLine();
        }
    }
}