using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Search
    {

        List<Album> mainData = new List<Album>();

        public void addToData(Album alb)
        {
            mainData.Add(alb);
        }

        public void FindSongsByName(string name)
        {

            foreach (Album alb in mainData)
            {

                foreach (Song song in alb.getSongs())
                {

                    if (song.checkByName(name))
                    {
                        song.show();
                    }
                }
            }
        }

        public void FindSongsBySinger(string singerName)
        {
            foreach (Album alb in mainData)
            {

                if (alb.getSingerName() == singerName)
                {
                    foreach (Song song in alb.getSongs())
                    {
                        song.show();
                    }
                }

            }
        }

        public void FindSongsByAge(int age)
        {

            foreach (Album alb in mainData)
            {

                foreach (Song song in alb.getSongs())
                {
                    if (song.checkByAge(age))
                    {
                        song.show();
                    }
                }
            }
        }

        public void FindSongsByGenre(string genre)
        {

            foreach (Album alb in mainData)
            {

                foreach (Genre gen in alb.getSinger().getGenres())
                {

                    if (gen.getName() == genre)
                    {

                        foreach (Song song in alb.getSongs())
                        {
                            if (song.checkByGenre(genre))
                            {
                                song.show();
                            }
                        }
                    }
                }
            }
        }

        public void FindAlbumsBySinger(string singer)
        {
            foreach (Album alb in mainData)
            {
                if (alb.getSingerName() == singer)
                {
                    Console.WriteLine(alb.getName());
                    foreach (Song song in alb.getSongs())
                    {
                        Console.Write("     ");
                        song.show();
                    }
                }
            }
        }

        public void FindAlbumsByName(string name)
        {
            foreach (Album alb in mainData)
            {
                if (alb.getName() == name)
                {
                    foreach (Song song in alb.getSongs())
                    {
                        song.show();
                    }
                }
            }
        }

        public void FindAlbumsByAge(int age) {
            foreach (Album alb in mainData) {
                if (alb.getAge() == age) {
                    Console.WriteLine(alb.getName());
                    foreach (Song song in alb.getSongs()) {
                        Console.Write("     ");
                        song.show();
                    }
                }
            }
        }
    }
}
