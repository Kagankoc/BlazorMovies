using BlazorMovies.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public interface IUsersRepository
    {
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO);
        Task<List<RoleDTO>> GetRoles();
        Task AssignRole(EditRoleDTO editRoleDTO);
        Task RemoveRole(EditRoleDTO editRoleDTO);
    }
}
