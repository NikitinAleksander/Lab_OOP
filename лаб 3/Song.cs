using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Song
    {

        private string name;
        private int age;
        private Album album;

        private Genre genre;

        public Song(string name, int age, Genre genre)
        {
            this.name = name;
            this.age = age;
            this.genre = genre;
        }

        public void show()
        {
            Console.WriteLine("{0} {1} {2} {3}", name, genre.getName(), age, album.getSinger().getName());
        }

        public bool checkByName(string name)
        {
            if (this.name == name)
            {
                return true;
            }
            return false;
        }

        public bool checkByAge(int age)
        {
            if (this.age == age)
            {
                return true;
            }
            return false;
        }

        public bool checkByGenre(string genre)
        {
            if (genre == this.genre.getName())
            {
                return true;
            }
            return false;
        }

        public void setAlbum(Album album) {
            this.album = album;
        }
    }
}
