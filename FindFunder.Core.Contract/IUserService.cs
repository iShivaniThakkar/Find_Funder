using FindFunder.Core.Domain.RequestModel;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;

namespace FindFunder.Core.Contract
{
    public interface IUserService
    {
        Task AddUserAsync(UserRequestModel user);

        Task<PagedList<User>> GetUserAsync(string searchTerm = null, int page = 1, int pageSize = 25);

        Task<User> UpdateUserAsync(long userId, UserRequestModel student);
        Task<User> GetIdByUserAsync(long userId);
    }

}