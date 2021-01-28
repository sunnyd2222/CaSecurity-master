using CaSecurity.Models;
using System.Collections.Generic;

namespace CaSecurity.ViewModels
{
    public class HomeVM
    {
        public string Tytul { get; set; }
        public List<User> Users { get; set; }
    }
}
