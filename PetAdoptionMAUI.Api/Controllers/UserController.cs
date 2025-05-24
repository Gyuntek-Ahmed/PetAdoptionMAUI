using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionMAUI.Api.Services.Interfaces;
using PetAdoptionMAUI.Shared.Dtos.Response;
using PetAdoptionMAUI.Shared.Dtos;
using System.Security.Claims;

namespace PetAdoptionMAUI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserPetService _userPetService;

        private int UserId
            => Convert.ToInt32(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public UserController(IUserPetService userPetService)
        {
            _userPetService = userPetService;
        }
        // api/user/adopt/1
        [HttpPost("adopt/{petId:int}")]
        public async Task<ApiResponse> AdoptPetAsync(int petId)
            => await _userPetService.AdoptPetAsync(UserId, petId);

        // api/user/adoptions
        [HttpGet("adoptions")]
        public async Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync()
            => await _userPetService.GetUserAdoptionsAsync(UserId);

        // api/user/favorites
        [HttpGet("favorites")]
        public async Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync()
            => await _userPetService.GetUserFavoritesAsync(UserId);

        // api/user/favorites/1
        [HttpPost("favorites/{petId:int}")]
        public async Task<ApiResponse> ToggleFavoritiesAsync(int petId)
            => await _userPetService.ToggleFavoritiesAsync(UserId, petId);
    }
}
