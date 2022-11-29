using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Genre
    {
        private string name;
        private List<Genre> und = new List<Genre>();

        public Genre(string name)
        {
            this.name = name;
        }

        void addUnd(Genre gen)
        {
            und.Add(gen);
        }

        public string getName()
        {
            return name;
        }
    }
}
