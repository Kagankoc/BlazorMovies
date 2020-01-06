using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>
        {
            new Movie(){Title = "Spider-Man: Far From Home",
                ReleaseDate = new DateTime(2019, 7, 2),
                Poster="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPzzfxN6Ugvq902Ut7A-QkCDOqLzzbiYQ2bPk2pn5D9fBZBrT_"
            },
            new Movie(){Title = "Rocky 2",
                ReleaseDate = new DateTime(2019, 7, 3),
            Poster="https://images-na.ssl-images-amazon.com/images/I/5190Z57CJPL._SY445_.jpg"
            },
            new Movie(){Title = "Back to the Future 3",
                ReleaseDate = new DateTime(1985, 7, 2),
            Poster="https://upload.wikimedia.org/wikipedia/en/thumb/4/4e/Back_to_the_Future_Part_III.jpg/220px-Back_to_the_Future_Part_III.jpg"
            }

        };
        }
    }
}
