using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
       
        Task<List<Person>> GetPeopleByName(string name);
        Task<Person> GetPersonById(int Id);
        Task UpdatePerson(Person person);
        Task DeletePerson(int id);
        Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO);
    }
}
