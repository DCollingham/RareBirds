using Microsoft.AspNetCore.Identity;
using RareBirdsApi.Data.Users;

namespace RareBirdsApi.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>>Register(UserDto userDto);
    }
}
