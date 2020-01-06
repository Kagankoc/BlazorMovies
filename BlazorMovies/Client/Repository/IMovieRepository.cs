using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public interface IMovieRepository
    {
        Task<int> CreateMovie(Movie movie);
        Task<IndexPageDTO> GetIndexPageDTO();
        Task<DetailsMovieDTO> GetDetailsMovieDTO(int id);
        Task<MovieUpdateDTO> GetMovieForUpdate(int id);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO);
    }
}
