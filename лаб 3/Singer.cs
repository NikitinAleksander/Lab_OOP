using lab3;
using System.Collections.Generic;
using System;

class Singer
{
    private string name;
    private int age;
    private List<Genre> mainGenre = new List<Genre>();

    private List<Album> albums = new List<Album>();

    public Singer(string name, int age, List<Genre> mainGenre)
    {
        this.name = name;
        this.age = age;
        this.mainGenre = mainGenre;
    }

    public void addAlbum(Album alb)
    {
        albums.Add(alb);
    }

    public string getName()
    {
        return name;
    }

    public List<Genre> getGenres()
    {
        return mainGenre;
    }

    public void addGenre(Genre name) {
        mainGenre.Add(name);
    }

    public void addGenre(List<Genre> genres) {
        foreach (Genre genre in genres) {
            mainGenre.Add(genre);
        }
    }
}