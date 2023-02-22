using AutoMapper;
using Find_Funder.Core.Builder;
using FindFunder.Core.Contract;
using FindFunder.Core.Domain.Exceptions;
using FindFunder.Core.Domain.RequestModel;
using FindFunder.Infra.Contract;
using FindFunder.Infra.Domain.Entities;
using FindFunder.Shared;

namespace FindFunder.Core.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddUserAsync(UserRequestModel userRequestModel)
        {
            try
            {
                var users = UserBuilder.Build(userRequestModel);
                var count = await _userRepository.AddUser(users);
                if(count==0)
                {
                    throw new BadRequestException("User is not Created Successfully!!!");
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedList<User>> GetUserAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var user = await _userRepository.GetUsers(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<User>>(user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetIdByUserAsync(long userId)
        {
            try
            {
                var user= await _userRepository.GetUserById(userId);
                if(user==null)
                {
                    throw new NotFoundException($"user with {userId} is NotFound");
                }
                return user;

            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<User> UpdateUserAsync(long userId, UserRequestModel usermodel)
        {
            try
            {
                var user = await _userRepository.GetUserById(userId);
                var userUpdate = await _userRepository.UpdateUser(userId, usermodel);
                userUpdate.UpdateData(usermodel.FirstName, usermodel.LastName, usermodel.Email);
                if (userUpdate == null)
                {
                    throw new NotFoundException($"User with {userId} is not found");
                }
                if (userUpdate == null)
                {
                    throw new BadRequestException("User is not Updated Successfully.");
                }
                return userUpdate;
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        
    }
}