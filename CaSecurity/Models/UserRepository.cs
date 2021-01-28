using System.Collections.Generic;
using System.Linq;

namespace CaSecurity.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    
        public User PobierzUserOId(int userId)
        {
            return _appDbContext.Users.FirstOrDefault(s => s.Id == userId);
        }

        public IEnumerable<User> PobierzWszystkieUsers()
        {
            return _appDbContext.Users;
        }

        public void DodajUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public void EdytujUser(User user)
        {
            _appDbContext.Users.Update(user);
            _appDbContext.SaveChanges();
        }

        public void UsunUser(User user)
        {
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
        }
    }
}
