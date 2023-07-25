using Microsoft.AspNetCore.Mvc;


namespace Inventar.Services
{
    public interface IUserService
    {
        string GetUserName();
        string GetUserRole();
    }
}
