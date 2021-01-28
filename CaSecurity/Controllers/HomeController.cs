using CaSecurity.Models;
using CaSecurity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaSecurity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = _userRepository.PobierzWszystkieUsers().OrderBy(s => s.Name);

            var homeVM = new HomeVM()
            {
                Tytul = "Przegląd pracowników GDi - Kontrola dostępu RFID do maszyn",
                Users = users.ToList()
            };

            return View(homeVM);
        }

        public IActionResult Szczegoly(int id)
        {
            var user = _userRepository.PobierzUserOId(id);

            if (user == null)
                return NotFound();

            return View(user);
        }
    }
}
