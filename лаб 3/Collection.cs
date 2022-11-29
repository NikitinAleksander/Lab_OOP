using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Collection
    {
        private List<Song> songs = new List<Song>();
        private string name;

        public Collection(string name)
        {
            this.name = name;
        }

        public void addSong(Song song)
        {
            songs.Add(song);
        }

        public void showCollection()
        {
            Console.WriteLine(name);
            foreach (Song song in songs)
            {
                song.show();
            }
        }

    }
}
