using System.Collections.Generic;
using System.Linq;

namespace CaSecurity.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> users;

        public MockUserRepository()
        {
            if (users == null)
            {
                ZaladujUsers();
            }
        }

        private void ZaladujUsers()
        {
            users = new List<User>
             {
                new User { Id=1, Name="Adam", Surname="Olesiewicz", Role="ControlEngineer", PermitionLevel = 9, PersonalCardId  = 3903, },
                
             };
        }

        public User PobierzUserOId(int userId)
        {
            return users.FirstOrDefault(s => s.Id == userId);
        }

        public IEnumerable<User> PobierzWszystkieUsers()
        {
            return users;
        }

        public void DodajUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void EdytujUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UsunUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
