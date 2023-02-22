using FindFunder.Core.Domain.RequestModel;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;

namespace FindFunder.Infra.Contract
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);

        Task<PagedList<User>> GetUsers(string? searchTerm = null, int page = 1, int pageSize = 50);

        Task<User> UpdateUser(long id, UserRequestModel model);
        Task<User> GetUserById(long userId);
    }
}