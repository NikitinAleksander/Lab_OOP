using System;
using System.Collections.Generic;

namespace lab3
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Genre gen1 = new Genre("Chill");
            Genre gen2 = new Genre("Ambient");
            List<Genre> genres = new List<Genre>();

            genres.Add(new Genre("Bass"));
            genres.Add(new Genre("Electronic"));

            Singer vacant = new Singer("VACANT", 30, new List<Genre>());
            vacant.addGenre(gen1);
            vacant.addGenre(gen2);

            Singer nulabee = new Singer("Nulabee", 45, new List<Genre>());
            nulabee.addGenre(genres);

            List<Song> songs = new List<Song>();
            songs.Add(new Song("Nocturnal", 2011, new Genre("Chill")));
            songs.Add(new Song("Afterlife", 2010, new Genre("Ambient")));
            songs.Add(new Song("Southbound", 2010, new Genre("Ambient")));
            songs.Add(new Song("One More Chance", 2012, new Genre("Chill")));
            songs.Add(new Song("Alone", 2012, new Genre("Chill")));

            Album albTest0 = new Album("Imminent", 2012, vacant, songs);

            List<Song> songs1 = new List<Song>();
            songs1.Add(new Song("Mythmaker", 2010, new Genre("Bass")));
            songs1.Add(new Song("Auroras", 2010, new Genre("Bass")));
            songs1.Add(new Song("Still Waters", 2019, new Genre("Bass")));
            songs1.Add(new Song("Distance", 2019, new Genre("Bass")));
            songs1.Add(new Song("Zephyr", 2019, new Genre("Electronic")));

            Album albTest1 = new Album("Bud Burst on the Ruins of Disarray", 2019, nulabee, songs1);

            List<Song> songs2 = new List<Song>();
            songs2.Add(new Song("Mythmaker", 2011, new Genre("Electronic")));
            songs2.Add(new Song("Mystic Forest", 2010, new Genre("Electronic")));
            songs2.Add(new Song("Twin Moons", 2018, new Genre("Electronic")));
            songs2.Add(new Song("Shivers", 2018, new Genre("Electronic")));
            songs2.Add(new Song("Sparckling Waves", 2018, new Genre("Electronic")));

            Album albTest2 = new Album("Queen for a Day", 2018, nulabee, songs2);

            Search search = new Search();

            search.addToData(albTest0);
            search.addToData(albTest1);
            search.addToData(albTest2);
            search.FindSongsBySinger("Nulabee");

            Console.WriteLine("---------------");

            search.FindSongsByName("Mythmaker");

            Console.WriteLine("---------------");

            search.FindSongsByAge(2010);

            Console.WriteLine("---------------");

            search.FindSongsByGenre("Electronic");

            Console.WriteLine("---------------");

            search.FindAlbumsBySinger("Nulabee");

            Console.WriteLine("---------------");

            search.FindAlbumsByName("Imminent");

            Console.WriteLine("---------------");

            search.FindAlbumsByAge(2019);

            Console.WriteLine("**************");

            Collection userCollection = new Collection("For work");
            userCollection.addSong(albTest0.getSongs()[0]);
            userCollection.addSong(albTest1.getSongs()[1]);
            userCollection.addSong(albTest2.getSongs()[2]);

            userCollection.showCollection();
            Console.Read();
        }
    }
}
