using MKIMovie.Models;

namespace MKIMovie.Services;

public static class MovieService
{
    static List<Movie> Movies { get; }
    static int nextId = 11;

    static MovieService()
    {
        Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "Interstellar",
                ReleaseDate = "26 de octubre de 2014",
                DirectedBy = "Christopher Nolan"
            },
            new Movie
            {
                Id = 2,
                Name = "The Shawshank Redemption",
                ReleaseDate = "14 de octubre de 1994",
                DirectedBy = "Frank Darabont"
            },
            new Movie
            {
                Id = 3,
                Name = "The Dark Knight",
                ReleaseDate = "18 de julio de 2008",
                DirectedBy = "Christopher Nolan"
            },
            new Movie
            {
                Id = 4,
                Name = "Pulp Fiction",
                ReleaseDate = "21 de octubre de 1994",
                DirectedBy = "Quentin Tarantino"
            },
            new Movie
            {
                Id = 5,
                Name = "Fight Club",
                ReleaseDate = "15 de octubre de 1999",
                DirectedBy = "David Fincher"
            },
            new Movie
            {
                Id = 6,
                Name = "Inception",
                ReleaseDate = "16 de julio de 2010",
                DirectedBy = "Christopher Nolan"
            },
            new Movie
            {
                Id = 7,
                Name = "The Matrix",
                ReleaseDate = "31 de marzo de 1999",
                DirectedBy = "The Wachowskis"
            },
            new Movie
            {
                Id = 8,
                Name = "Forrest Gump",
                ReleaseDate = "6 de julio de 1994",
                DirectedBy = "Robert Zemeckis"
            },
            new Movie
            {
                Id = 9,
                Name = "The Godfather",
                ReleaseDate = "24 de marzo de 1972",
                DirectedBy = "Francis Ford Coppola"
            },
            new Movie
            {
                Id = 10,
                Name = "The Lord of the Rings: The Fellowship of the Ring",
                ReleaseDate = "19 de diciembre de 2001",
                DirectedBy = "Peter Jackson"
            }
        };
    }

    public static List<Movie> GetAll() => Movies;

    public static Movie? Get(int id) => Movies.FirstOrDefault(movie => movie.Id == id);

    public static void Add(Movie movie)
    {
        movie.Id = nextId++;
        Movies.Add(movie);
    }

    public static void Delete(int id)
    {
        var movie = Get(id);
        if (movie is null)
            return;
        Movies.Remove(movie);
    }

    public static void Update(Movie movie)
    {
        var index = Movies.FindIndex(m => m.Id == movie.Id);
        if (index == -1)
            return;
        Movies[index] = movie;
    }
}
