using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RareBirdsApi.Contracts;
using RareBirdsApi.Data.Users;

namespace RareBirdsApi.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        async Task<IEnumerable<IdentityError>> IAuthManager.Register(UserDto userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;

        }
    }
}
