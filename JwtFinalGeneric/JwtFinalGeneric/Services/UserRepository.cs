using JwtFinalGeneric.Interfaces;
using JwtFinalGeneric.Models;
using System.Linq;

namespace JwtFinalGeneric.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        readonly XContext _xcontext;

        public UserRepository(XContext xcontext):base(xcontext)
        {
            _xcontext = xcontext;
        }

        User IUserRepository.FindUsername(string username)
        {
            return _xcontext.Set<User>().FirstOrDefault(a => a.username == username);
        }

    }
}
