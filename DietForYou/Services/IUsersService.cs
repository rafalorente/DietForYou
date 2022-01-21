using DietForYou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Services
{
    public interface IUsersService
    {

        Task<IEnumerable<Users>> GetUsers();

        Task<Users> GetUsers(int id);

        Task<IEnumerable<Users>> GetUsersByNome(string nome);

        Task CreateUsers(Users users);

        Task UpdateUsers(Users users);

        Task DeleteUsers(Users users);
    }
}
