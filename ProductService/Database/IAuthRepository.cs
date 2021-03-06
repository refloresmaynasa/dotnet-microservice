﻿namespace ProductService.Database
{
    using ProductService.Database.Entities;
    using System.Threading.Tasks;

    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string pasword);
        Task<bool> UserExists(string username);
    }
}
