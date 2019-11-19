﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RoeiJeRot.Database.Database;

namespace RoeiJeRot.Logic.Services
{
    /// <summary>
    /// Interface for logic that retrieves user data from database.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///  Returns a list of users from the database.
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly RoeiJeRotDbContext _context;

        public UserService(RoeiJeRotDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
