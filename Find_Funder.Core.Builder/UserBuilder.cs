using FindFunder.Core.Domain.RequestModel;
using FindFunder.Infra.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Find_Funder.Core.Builder
{
    public static class UserBuilder
    {
        public static User Build(UserRequestModel model)
        {
            var hmac = new HMACSHA512();
            return new User(model.FirstName, model.LastName,model.Email, hmac.ComputeHash(Encoding.ASCII.GetBytes(model.Password)),hmac.Key);
        }
    }
}