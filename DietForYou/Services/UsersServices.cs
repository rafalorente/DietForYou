using DietForYou.Data;
using DietForYou.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Services
{
    public class UsersServices : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch 
            {
                throw;
            }
        }

        public async Task<IEnumerable<Users>> GetUsersByNome(string nome)
        {
            IEnumerable<Users> users;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                users = await _context.Users.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                users = await GetUsers();
            }
            return users;
        }

        public async Task<Users> GetUsers(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task CreateUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsers(Users users)
        {
            _context.Entry(users).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsers(Users users)
        {
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
        }
        
    }
}
