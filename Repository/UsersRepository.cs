﻿using LibrarySystemWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWeb.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository( ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<Users?> VerifyAuthentication( string email, string password )
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync( x => x.Email == email && x.Password == password );
        }

        public async Task<Users?> GetByEmail( string email )
        {
            return await _dbContext.Users.FirstOrDefaultAsync( u => u.Email == email );
        }

        public async Task<bool> EmailAlreadyRegistered( string email )
        {
            return await _dbContext.Users
                .AnyAsync( x => x.Email == email );
        }

        public async Task<Users?> AddUser( Users user )
        {
            await _dbContext.Users.AddAsync( user );
            return user;
        }

    }
}