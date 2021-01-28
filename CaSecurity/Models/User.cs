namespace CaSecurity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public int PermitionLevel { get; set; }
        public int PersonalCardId { get; set; }

    }
}
