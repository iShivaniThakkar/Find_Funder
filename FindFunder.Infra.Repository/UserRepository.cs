using FindFunder.Core.Domain.RequestModel;
using FindFunder.Infra.Contract;
using FindFunder.Infra.Domain;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;
using Microsoft.EntityFrameworkCore;

namespace FindFunder.Infra.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly FindFunderContext _context;
        public UserRepository(FindFunderContext context)
        {
            _context = context;
        }
        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedList<User>> GetUsers(string? searchTerm = null, int page = 1, int pageSize = 50)
        {
            try
            {
                var users = _context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    users = users.Where(x =>
                    EF.Functions.Like(x.FirstName, $"%{searchTerm}%")

                    );
                }

                var count = await users.LongCountAsync();
                var pagedList = users.ToPagedList(page, pageSize, count);

                return pagedList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> UpdateUser(long userId, UserRequestModel user)
        {
            var match = _context.Users.FirstOrDefault(x => x.Id == userId);

            match.UpdateData(user.FirstName, user.LastName, user.Email);
            
            _context.Users.Update(match);

            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<User> GetUserById(long userId)
        {
            var users=await _context.Users.FirstOrDefaultAsync(x=>x.Id== userId);
            return users;
            //comment
        }
    }
}