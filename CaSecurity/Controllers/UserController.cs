using CaSecurity.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CaSecurity.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View(_userRepository.PobierzWszystkieUsers());
        }

        public IActionResult Details(int id)
        {
            var user = _userRepository.PobierzUserOId(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.DodajUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(int Id)
        {
            var user = _userRepository.PobierzUserOId(Id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user) 
        {
            if (ModelState.IsValid)
            {
                _userRepository.EdytujUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(int Id)
        {
            var user = _userRepository.PobierzUserOId(Id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userRepository.PobierzUserOId(id);
            _userRepository.UsunUser(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
