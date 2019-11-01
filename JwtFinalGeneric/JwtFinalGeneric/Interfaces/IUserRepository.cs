using JwtFinalGeneric.Models;

namespace JwtFinalGeneric.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User FindUsername(string username);
    }
}
