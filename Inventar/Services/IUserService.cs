using User.Models;
using Microsoft.AspNetCore.Mvc;


namespace User.Services
{
    public interface IUserService
    {
        string GetUserName();
        string GetUserRole();
    }
}
