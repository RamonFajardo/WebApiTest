using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUser(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<User> Register(User user, string password);

        Task<User> LoginAsync(string username, string password);

    }
}
