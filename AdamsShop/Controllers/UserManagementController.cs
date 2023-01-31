using AdamsShop.DataModel;
using AdamsShop.Models;
using AdamsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMyPasswordHasher _myPasswordHasher;

        public UserManagementController(IUserRepository userRepository, IMyPasswordHasher myPasswordHasher)
        {
            _userRepository = userRepository;
            _myPasswordHasher=myPasswordHasher;
        }

        public IActionResult MyRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyRegister(MyUser myUser)
        {
            List<MyUser> MyUsers = _userRepository.GetAllUsers();

            if (MyUsers.Any(u => u.EmailAddress == myUser.EmailAddress))
            {
                ModelState.AddModelError("", "The account registered to this email address already exists!!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _userRepository.CreateUser(myUser);
                return RedirectToAction("Registered");
            }
            return View();
        }

        public IActionResult Registered()
        {
            ViewData["RegisteredMessage"] = "You have registered succesfully!!";
            return View();
        }

        public IActionResult MyLogin(string returnUrl)
        {

            if (HttpContext.Session.GetString("Id") != null)
            {
                return LocalRedirect(returnUrl);
            }

            return View(new MyLoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult MyLogin(MyLoginViewModel myLoginViewModel, string returnUrl)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return LocalRedirect(returnUrl);
            }

            List<MyUser> MyUsers = _userRepository.GetAllUsers();
            var exsistingUser = MyUsers.FirstOrDefault(u => u.EmailAddress == myLoginViewModel.EmailAddress);

            if (exsistingUser == null)
            {
                ModelState.AddModelError("", "This email address is not registered!!");
                return View();
            }

            if (_myPasswordHasher.VerifyMyPassword(exsistingUser.Password, myLoginViewModel.Password) == false)
            {
                ModelState.AddModelError("", "Incorrect password!!");
                return View();
            }

            if (ModelState.IsValid)
            {
                Request.HttpContext.Session.SetString("Id", Guid.NewGuid().ToString());
                Request.HttpContext.Session.SetString("MyUserName", exsistingUser.Name);
                return LocalRedirect(returnUrl);
            }

            return View();
        }

        public IActionResult MyLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("MyUserName");

            return RedirectToAction("MyLogin");
        }
    }
}
