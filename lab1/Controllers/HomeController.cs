using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using lab1.Models;
using Newtonsoft.Json;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        private const string FilePath = "~/Server_Content/Database.txt";
        private IUserRepository _userRepository;
        private ICapchaRepository _capchaRepository;

        public HomeController(IUserRepository userRepository, ICapchaRepository capchaRepository)
        {
            _userRepository = userRepository;
            _capchaRepository = capchaRepository;
        }

        public HomeController() : this(
            new FileUserRepository(HostingEnvironment.MapPath(FilePath)),
            new FileCapchaRepository(HostingEnvironment.MapPath(FilePath)))
        {
        }

        private void fillData()
        {
            var users =
                new List<User>(new User[]
                {
                    new User() {UserName = "admin", Password = "admin"},
                    new User() {UserName = "user1", Password = "password"},
                    new User() {UserName = "user2", Password = "password"}
                });
            var capcha = new CapchaFunc() {FunctionA = 2, FunctionB = 3};
            var obj = new JsonData() {Users = users, FunctionInfo = capcha};
            var json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(Server.MapPath("~/Server_Content/Database.txt"), json);
        }

        private string capchaText()
        {
            var a = _capchaRepository.FunctionA;
            var b = _capchaRepository.FunctionB;
            var currentx = new Random().Next(1, 11);
            _capchaRepository.CurrentX = currentx;
            return $"y = {a}*{currentx} {(Math.Sign(b) > 0 ? "+ " + b : "- " + Math.Abs(b))}";
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewData["CapchaText"] = capchaText();
            ViewData["DivIsVisible"] = "collapse";
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // Get: ConfirmRegister
        [HttpPost]
        public ActionResult ConfirmRegister(RegisterModel model)
        {
            if (model == null) return View("Register");
            if (!string.Equals(model.Password, model.RetryPassword))
                return View("Register");
            _userRepository.AddUser(new User() {UserName = model.UserName, Password = model.Password});
            ViewData["CapchaText"] = capchaText();
            return View("Index");
        }

        // GET: Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = _userRepository.GetUser(model.UserName);
            int res;
            if (user != null && string.Equals(user.Password, model.Password)
                && int.TryParse(model.Capcha, out res)
                && res == _capchaRepository.FunctionA*_capchaRepository.CurrentX + _capchaRepository.FunctionB)
            {
                var resModel = new AuthModel() {UserName = model.UserName};
                return View(resModel);
            }
            ViewData["DivIsVisible"] = "visible";
            ViewData["CapchaText"] = capchaText();
            return View("Index");
        }
    }
}