using lab3;
using System;
using System.Collections.Generic;

class Album
{
    private string name;
    private int age;
    private Singer albSing;

    private List<Song> songs = new List<Song>();

    public Album(string name, int age, Singer albSing, List<Song> songs)
    {
        this.name = name;
        this.age = age;
        this.albSing = albSing;
        this.songs = songs;

        foreach (Song song in songs) {
            song.setAlbum(this);
        }
    }

    public List<Song> getSongs()
    {
        return songs;
    }

    public string getSingerName()
    {
        return albSing.getName();
    }

    public Singer getSinger()
    {
        return albSing;
    }

    public string getName()
    {
        return name;
    }

    public int getAge() 
    {
        return age;
    }
}