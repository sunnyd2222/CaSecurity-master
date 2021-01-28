using System.Collections.Generic;

namespace CaSecurity.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> PobierzWszystkieUsers();
        User PobierzUserOId(int userId);

        void DodajUser(User user);
        void EdytujUser(User user);
        void UsunUser(User user);
    }
}
