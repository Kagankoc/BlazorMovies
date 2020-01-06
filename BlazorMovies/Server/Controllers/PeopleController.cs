using AutoMapper;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;

        public PeopleController(ApplicationDbContext context,IFileStorageService fileStorageService,IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        } 

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            if(!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorageService.SaveFile(personPicture, "jpg", "people");
            }

            context.Add(person);
            await context.SaveChangesAsync();
            return person.Id;
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { return new List<Person>(); }
            return await context.People
                .Where(x => x.Name.Contains(searchText))
                .Take(5)
                .ToListAsync();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Person>>> Get([FromQuery]PaginationDTO paginationDTO)
        {
            var queryable = context.People.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            
            return await queryable.Paginate(paginationDTO).ToListAsync();
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var result= await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if(result==null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpPut]
        public async Task<ActionResult> Put(Person person)
        {
            var personDb = await context.People.FirstOrDefaultAsync(x => x.Id == person.Id);
            if(personDb==null)
            {
                return NotFound();
            }
            personDb = mapper.Map(person, personDb);
            if(!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                personDb.Picture = await fileStorageService.EditFile(personPicture, "jpg", "people", personDb.Picture);
            }
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == Id);
            if (person == null)
            {
                return NotFound();
            }
            context.Remove(person);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
